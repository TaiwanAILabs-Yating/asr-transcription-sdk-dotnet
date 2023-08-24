using YatingAsrTranscriptionClient;
using YatingAsrTranscriptionClient.Asr;
using YatingAsrTranscriptionClient.Constants;

string asrApiUrl = "ASR_ENDPOINT";
string asrApiKey = "PUT_YOUR_API_KEY_HERE";


string audioUri = "http://www.audio.com/audio_file.wav";
string asrModel = AsrModel.ZHTW;
bool speakerDiarization = true;
int speakerCount = 0;
bool sentiment = false;


try
{
    AsrClient asrClient = new AsrClient(asrApiUrl, asrApiKey);
    Sentence[] sentences = asrClient.Transcription(audioUri, asrModel, speakerDiarization, speakerCount, sentiment);

    foreach (Sentence sentence in sentences)
    {
        Console.WriteLine($"{sentence.GetSentence()} ");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
