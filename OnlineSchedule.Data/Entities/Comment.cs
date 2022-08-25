using System.ComponentModel.DataAnnotations;

namespace OnlineSchedule.Data.Entities
{
    public class Comment : BaseEntity<Guid>
    {
        //[Required]
        //[MaxLength(500)]
        public string Text { get; set; }

        //[Required]
        public DateTime DateOfCreation { get; set; }

        public int PositiveRating { get; set; }
        public int NegativeRating { get; set; }

        public bool IsFixed { get; set; }
        public int FixedPosition { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime DateOfRemoved { get; set; }

        public Guid ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
