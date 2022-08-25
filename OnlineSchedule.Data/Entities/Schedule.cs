using System.ComponentModel.DataAnnotations;

namespace OnlineSchedule.Data.Entities
{
    public class Schedule : BaseEntity<Guid>
    {
        [Required]
        [MinLength(5), MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(3500)]
        public string About { get; set; }

        public bool CommentsIsAllow { get; set; }

        [Required]
        public DateTime DateOfCreation { get; set; }

        [Required]
        public int Position { get; set; }

        public int ComplaintsCount { get; set; }

        public List<Day> Days { get; set; }
        
        public List<Comment> Comments { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
