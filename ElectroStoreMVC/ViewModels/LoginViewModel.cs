using System.ComponentModel.DataAnnotations;

namespace ElectroStoreMVC.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Поле Email обязательное для заполнения!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле пароль обязательное для заполнения!")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
