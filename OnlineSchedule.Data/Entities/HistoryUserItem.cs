namespace OnlineSchedule.Data.Entities
{
    public class HistoryUserItem : HistoryItem
    {
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
