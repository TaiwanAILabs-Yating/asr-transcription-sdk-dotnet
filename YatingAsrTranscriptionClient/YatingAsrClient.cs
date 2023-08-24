using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;

using YatingAsrTranscriptionClient.Asr;
using YatingAsrTranscriptionClient.Constants;
using YatingAsrTranscriptionClient.Dto;

namespace YatingAsrTranscriptionClient
{
    public class AsrClient
    {

        private readonly string AsrApiUrl;
        private readonly string AsrApiKey;

        public AsrClient(string asrApiUrl, string asrApiKey)
        {
            this.AsrApiUrl = asrApiUrl;
            this.AsrApiKey = asrApiKey;
        }

        public Sentence[] Transcription(string audioUri, string asrModel, bool speakerDiarization,int speakerCount, bool sentiment)
        {
            try
            {
                // parameter validation
                Validation(asrModel);

                // mapping http request body
                StringContent bodyString = BodyGenerator(audioUri, asrModel, speakerDiarization, speakerCount, sentiment);

                // send http post request
                ResponseDto responseDto = SendHttpRequest(bodyString);

                string transcriptionId = responseDto.Uid;
                string status = responseDto.Status;
                Console.WriteLine($"[{transcriptionId}] Send task success");

                //get http result
                while (!TaskStatus.IsFinish(status))
                {
                    Thread.Sleep(5000);
                    responseDto = GetHttpRequest(transcriptionId);
                    status = responseDto.Status;
                    Console.WriteLine($"[{transcriptionId}] Get task status success, status: {status}");
                }

                if (status != TaskStatus.Completed)
                {
                    throw new Exception("Transcription not completed, status: " + status);
                }

                if (responseDto.Sentences == null)
                {
                    throw new Exception("Sentences is null");
                }

                return responseDto.Sentences;
            }
            catch
            {
                throw;
            }
        }

        private ResponseDto GetHttpRequest(string transcriptionId)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("key", AsrApiKey);

            try
            {
                HttpResponseMessage httpResponseMessage = httpClient.GetAsync(AsrApiUrl+"/"+ transcriptionId).Result;

                // Get request
                int statusCode = (int)httpResponseMessage.StatusCode;
                if (statusCode != 200 && statusCode != 201)
                {
                    throw new HttpRequestException($"http request error, error code: {statusCode}");
                }

                string content = httpResponseMessage.Content.ReadAsStringAsync().Result;

                // Decode body result
                ResponseDto? responseDto = JsonSerializer.Deserialize<ResponseDto>(content);
                if (responseDto is null)
                {
                    throw new ArgumentNullException(nameof(responseDto));
                }

                return responseDto;
            }
            catch
            {
                throw;
            }
        }

        private ResponseDto SendHttpRequest(StringContent bodyString)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("key", AsrApiKey);

            try
            {
                HttpResponseMessage httpResponseMessage = httpClient.PostAsync(AsrApiUrl, bodyString).Result;

                // Get request
                int statusCode = (int)httpResponseMessage.StatusCode;
                if (statusCode != 200 && statusCode != 201)
                {
                    throw new HttpRequestException($"http request error, error code: {statusCode}");
                }

                string content = httpResponseMessage.Content.ReadAsStringAsync().Result;

                // Decode body result
                ResponseDto[]? responseDtos = JsonSerializer.Deserialize<ResponseDto[]>(content);
                if (responseDtos is null)
                {
                    throw new ArgumentNullException(nameof(responseDtos));
                }

                return responseDtos[0];
            }
            catch
            {
                throw;
            }
        }

        private StringContent BodyGenerator(string audioUri, string asrModel, bool speakerDiarization, int speakerCount, bool sentiment)
        {
            RequestDto request = new RequestDto(audioUri, asrModel, speakerDiarization, speakerCount, sentiment);
            string jsonString = JsonSerializer.Serialize(request);
            Console.WriteLine($"Post Body Json String: {jsonString}");

            StringContent jsonEncodeString = new StringContent(jsonString, Encoding.UTF8, "application/json");
            return jsonEncodeString;
        }

        private void Validation(string asrModel)
        {
            if (!AsrModel.Validation(asrModel))
            {
                throw new Exception("asrModel: " + asrModel + " is not allowed.");
            }
        }
    }
}

