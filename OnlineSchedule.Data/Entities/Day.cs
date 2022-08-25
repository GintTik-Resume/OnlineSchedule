using System.ComponentModel.DataAnnotations;

namespace OnlineSchedule.Data.Entities
{
    public class Day : BaseEntity<Guid>
    {
        [Required]
        [MinLength(5), MaxLength(255)]
        public string Title { get; set; }

        [Required]
        public DateTime DateOfCreation { get; set; }

        [Required]
        public int Position { get; set; }
        
        public Guid ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

        public List<Lesson> Lessons { get; set; }
    }
}
