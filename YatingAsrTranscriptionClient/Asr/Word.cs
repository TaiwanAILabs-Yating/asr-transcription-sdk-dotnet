using System.Text.Json.Serialization;

namespace YatingAsrTranscriptionClient.Asr
{
    public class Word
    {
        [JsonPropertyName("word")]
        public string word { get; set; }
        [JsonPropertyName("punctuator")]
        public string punctuator { get; set; }
        [JsonPropertyName("start")]
        public int start { get; set; }
        [JsonPropertyName("end")]
        public int end { get; set; }

        public string GetWord()
        {
            return word;
        }
    }
}

