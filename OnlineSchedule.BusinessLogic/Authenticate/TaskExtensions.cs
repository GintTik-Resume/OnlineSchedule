namespace OnlineSchedule.BusinessLogic.Authenticate
{
    public static class TaskExtensions
    {
        public static T GetResult<T>(this Task<T> task)
        {
            return task.GetAwaiter().GetResult();
        }

        public static void GetResult(this Task task)
        {
            task.GetAwaiter().GetResult();
        }
    }
}
