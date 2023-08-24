using System.Text.Json.Serialization;

namespace YatingAsrTranscriptionClient.Asr
{
    public class Sentence
    {
        [JsonPropertyName("sentence")]
        public string sentence { get; set; }
        [JsonPropertyName("confidence")]
        public double confidence { get; set; }
        [JsonPropertyName("start")]
        public int start { get; set; }
        [JsonPropertyName("end")]
        public int end { get; set; }
        [JsonPropertyName("speakerId")]
        public string speakerId { get; set; }
        [JsonPropertyName("sentiment")]
        public int sentiment { get; set; }
        [JsonPropertyName("words")]
        public Word[] Words { get; set; }

        public string GetSentence()
        {
            return sentence;
        }

        public string GetSentenceByWords()
        {
            string sentence = "";
            foreach (Word word in Words)
            {
                sentence += word.GetWord();
            }

            return sentence;
        }
    }
}

