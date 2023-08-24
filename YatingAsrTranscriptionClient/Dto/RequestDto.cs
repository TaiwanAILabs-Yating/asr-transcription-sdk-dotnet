using System.Text.Json.Serialization;

namespace YatingAsrTranscriptionClient.Dto
{
    public class RequestDto
    {
        [JsonPropertyName("audioUri")]
        public string AudioUri { get; set; }
        [JsonPropertyName("modelConfig")]
        public ModelConfigDto ModelConfig { get; set; }
        [JsonPropertyName("featureConfig")]
        public FeatureConfigDto FeatureConfig { get; set; }

        public RequestDto(string audioUri, string asrModel, bool speakerDiarization, int speakerCount, bool sentiment)
        {
            this.AudioUri = audioUri;
            this.ModelConfig = new ModelConfigDto(asrModel,"");
            this.FeatureConfig = new FeatureConfigDto(speakerDiarization, speakerCount, sentiment);
        }
    }

    public class ModelConfigDto
    {
        [JsonPropertyName("model")]
        public string Model { get; set; }
        [JsonPropertyName("customLm")]
        public string CustomLm { get; set; }

        public ModelConfigDto(string model, string customLm)
        {
            this.Model = model;
            this.CustomLm = customLm;
        }
    }

    public class FeatureConfigDto
    {
        [JsonPropertyName("punctuation")]
        public bool Punctuation { get; set; }
        [JsonPropertyName("speakerDiarization")]
        public bool SpeakerDiarization { get; set; }
        [JsonPropertyName("speakerCount")]
        public int SpeakerCount { get; set; }
        [JsonPropertyName("sentiment")]
        public bool Sentiment { get; set; }

        public FeatureConfigDto(bool speakerDiarization,int speakerCount,bool sentiment)
        {
            this.Punctuation = true;
            this.SpeakerDiarization = speakerDiarization;
            this.SpeakerCount = speakerCount;
            this.Sentiment = sentiment;
        }
    }
}
