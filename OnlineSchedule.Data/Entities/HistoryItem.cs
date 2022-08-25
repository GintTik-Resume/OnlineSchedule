using System.ComponentModel.DataAnnotations;

namespace OnlineSchedule.Data.Entities
{
    public class HistoryItem : BaseEntity<Guid>
    {
        [Required]
        public string PerformerId { get; set; }
        public User Performer { get; set; }

        [Required]
        public DateTime DateOfAction { get; set; }

        [Required]
        public Guid TypeOfActionId { get; set; }
        public TypeOfAction TypeOfAction { get; set; }
    }
}
