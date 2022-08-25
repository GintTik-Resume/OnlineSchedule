using System.ComponentModel.DataAnnotations;

namespace OnlineSchedule.Data.Entities
{
    public class TypeOfAction : BaseEntity<Guid>
    {
        [Required]
        public string Name { get; set; }
    }
}
