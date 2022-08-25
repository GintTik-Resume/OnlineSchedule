using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSchedule.Data.Entities
{
    public class User : IdentityUser
    {
        [Required]
        [MinLength(5), MaxLength(100)]
        public string Name { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime DateOfRemoving { get; set; }

        public List<Schedule> Schedules { get; set; }
    }
}
