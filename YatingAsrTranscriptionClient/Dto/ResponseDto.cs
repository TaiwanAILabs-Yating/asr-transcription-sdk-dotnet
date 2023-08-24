using System.Text.Json.Serialization;
using YatingAsrTranscriptionClient.Asr;

namespace YatingAsrTranscriptionClient.Dto
{
    public class ResponseDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("uid")]
        public string Uid { get; set; }
        [JsonPropertyName("audioUri")]
        public string AudioUri { get; set; }
        [JsonPropertyName("model")]
        public string Model { get; set; }
        [JsonPropertyName("customLm")]
        public string CustomLm { get; set; }
        [JsonPropertyName("isPunctuation")]
        public int IsPunctuation { get; set; }
        [JsonPropertyName("isSpeakerDiarization")]
        public int IsSpeakerDiarization { get; set; }
        [JsonPropertyName("speakerCount")]
        public int SpeakerCount { get; set; }
        [JsonPropertyName("isSentiment")]
        public int IsSentiment { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; set; }
        [JsonPropertyName("updatedAt")]
        public string UpdatedAt { get; set; }
        [JsonPropertyName("sentences")]
        public Sentence[]? Sentences { get; set; }
    }
}
