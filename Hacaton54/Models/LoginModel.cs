using System.ComponentModel.DataAnnotations;
using Hacaton54.Models.ModelDB;

namespace Hacaton54.Models
{
    public class LoginModel
    {

        [Required(ErrorMessage = "Не указан UserRole")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
