using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Games_Library.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public int Hours { get; set; }

        //foreign keys
        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Game")]
        public int GameId { get; set; }

        //Navigation properties
        public User User { get; set; }
        public Game Game { get; set; }
    }
}
