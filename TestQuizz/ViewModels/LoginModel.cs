using System.ComponentModel.DataAnnotations;


namespace TestQuizz.ViewModels
{

    public class LoginModel
    {
        [Required(ErrorMessage = "Не указано имя пользователя")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool[] Access { get; set; }

    }

}
