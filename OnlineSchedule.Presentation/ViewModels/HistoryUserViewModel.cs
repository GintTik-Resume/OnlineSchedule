using OnlineSchedule.Data.Entities;

namespace OnlineSchedule.Presentation.ViewModels
{
    public class HistoryUserViewModel
    {
        public string UserEmail { get; set; }
        public string PerformerEmail { get; set; }
        public DateTime DateOfAction { get; set; }
        public string PerformerRole { get; set; }
        public string TypeOfAction { get; set; }
    }
}
