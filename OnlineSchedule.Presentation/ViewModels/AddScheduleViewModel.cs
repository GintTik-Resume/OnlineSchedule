using System.ComponentModel.DataAnnotations;

namespace OnlineSchedule.Presentation.ViewModels
{
    public class AddScheduleViewModel
    {
        [Required(ErrorMessage = "Поле назви обов'язкове")]
        [MinLength(5, ErrorMessage = "Мінімальна кількість символів в назві - 5")]
        [MaxLength(100, ErrorMessage = "Максимальна кількість символів - 100")]
        public string Title { get; set; }

        public string About { get; set; }

        public bool AllowComments { get; set; }
    }
}
