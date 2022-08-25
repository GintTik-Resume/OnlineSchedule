using System.ComponentModel.DataAnnotations;

namespace OnlineSchedule.Presentation.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Поле почти обов'язкове")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Дані не відповідають почті")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле паролю є обов'язковим")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
