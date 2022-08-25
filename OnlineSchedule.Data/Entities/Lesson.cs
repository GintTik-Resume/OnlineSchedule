using System.ComponentModel.DataAnnotations;

namespace OnlineSchedule.Data.Entities
{
    public class Lesson : BaseEntity<Guid>
    {
        [Required]
        [MinLength(5), MaxLength(255)]
        public string Title { get; set; }

        [Required]
        public DateTime DateOfCreation { get; set; }

        [Required]
        public int Position { get; set; }

        public Guid DayId { get; set; }
        public Day Day { get; set; }
    }
}
