using System.ComponentModel.DataAnnotations;

namespace AutoTradeHub.ViewModels
{
	public class LoginVM
	{
		[Required(ErrorMessage = "Введите электронную почту!")]
		[Display(Name = "Адрес электронной почты")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Введите пароль!")]
		[DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
	}
}
