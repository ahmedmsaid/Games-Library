using System.ComponentModel.DataAnnotations;

namespace Games_Library.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        public string Password { get; set; }

        public string Message { get; set; } = "";
    }
}
