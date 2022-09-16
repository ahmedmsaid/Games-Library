using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Games_Library.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "Name must be more than 3 letters")]
        public string Name { get; set; }

        [MinLength(3, ErrorMessage = "Nickname must be more than 3 letters")]
        public string? Nickname { get; set; }

        [Required]
        public string Gender { get; set; }

        public string Avatar { get; set; } //profile picture

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password", ErrorMessage = "password does not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }

        [Required]
        [Range(13, 99, ErrorMessage = "Age must be between 13 and 99")]
        public int Age { get; set; }

        [RegularExpression("^01[0125][0-9]{8}$", ErrorMessage = "Phone Number is not valid")]
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; } = false;
        public List<User>? Friends { get; set; }


        //Navigation properties
        [ForeignKey("Games")]
        public int? GameId { get; set; }
        public List<Game>? Games { get; set; }

        //reviews

    }
}
