using System;
using System.Linq;

namespace YatingAsrTranscriptionClient.Constants
{
    public class TaskStatus
    {
        public static string Pending = "pending";
        public static string Ongoing = "ongoing";
        public static string Completed = "completed";
        public static string Expired = "expired";
        public static string Error = "error";

        public static bool Validation(string taskStatus)
        {
            string[] taskStatuss = { Pending, Ongoing, Completed, Expired, Error };
            return taskStatuss.Contains(taskStatus);
        }

        public static bool IsFinish(string taskStatus)
        {
            return (taskStatus == Completed || taskStatus == Expired || taskStatus == Error);
        }
    }
}
