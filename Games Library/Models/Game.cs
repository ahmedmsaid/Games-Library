using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Games_Library.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "Name must be more than 3 letters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        [MinLength(2, ErrorMessage = "Genre must be more than 3 letters")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Publisher is required")]
        [MinLength(2, ErrorMessage = "Publisher name must be more than 3 letters")]
        public string Publisher { get; set; }
        public string Img { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [DataType(DataType.Currency)]
        public float Price { get; set; }

        [Required(ErrorMessage = "Rate is required")]
        public float Rate { get; set; }

        [Required(ErrorMessage = "Release date is required")]
        public DateOnly ReleaseDate { get; set; }

        public SysReq SysReq { get; set; }

        //foreign keys
        [ForeignKey("Players")]
        public int? UserId { get; set; }

        [ForeignKey("Reviews")]
        public int? ReviewId { get; set; }

        //Navigation Properties
        public List<User>? Players { get; set; }

        public List<Review>? Reviews { get; set; }

    }
}
