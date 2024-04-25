using System.ComponentModel.DataAnnotations;

namespace AutoTradeHub.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Введите электронную почту!")]
        [Display(Name = "Адрес электронной почты")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Введите пароль!")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Пароль должен содержать не менее 3 символов!")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Подтвердите пароль!")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают!")]
        public string? ConfirmPassword { get; set; }
    }
}
