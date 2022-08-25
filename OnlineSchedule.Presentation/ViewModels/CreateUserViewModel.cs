using System.ComponentModel.DataAnnotations;

namespace OnlineSchedule.Presentation.ViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "Поле почти обов'язкове")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Дані не відповідають почті")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле імені обов'язкове")]
        [MinLength(5, ErrorMessage = "Ім'я не може бути менше 5 символів")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле паролю є обов'язковим")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        public string ConfirmPassword { get; set; }

        public string Role { get; set; }
    }
}
