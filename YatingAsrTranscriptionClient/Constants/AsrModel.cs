using System.Linq;

namespace YatingAsrTranscriptionClient.Constants
{
    public class AsrModel
    {
        public static string ZHEN = "asr-zh-en-std";
        public static string ZHTW = "asr-zh-tw-std";
        public static string EN = "asr-en-std";

        public static bool Validation(string asrModel)
        {
            string[] asrModels = { ZHEN, ZHTW, EN };
            return asrModels.Contains(asrModel);
        }
    }
}
