namespace OnlineSchedule.Data.Entities
{
    public class HistoryScheduleItem : HistoryItem
    {
        public string ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
    }
}
