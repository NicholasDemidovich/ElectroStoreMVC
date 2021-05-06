using System.ComponentModel.DataAnnotations;

namespace ElectroStoreMVC.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email введен некорректно!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле логин обязательное для заполнения!")]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле ФИО обязательное для заполнения!")]
        [Display(Name = "ФИО")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Поле Адрес обязательное для заполнения!")]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Поле Email обязательное для заполнения!")]
        [RegularExpression(@"^(\+[0-9]{12})$", ErrorMessage = "Номер телефона не удовлетворяет требованиям!")]
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Поле пароль обязательное для заполнения!")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле подтвердить пароль обязательное для заполнения!")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}
