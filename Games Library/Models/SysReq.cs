using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Games_Library.Models
{
    public class SysReq
    {
        [ForeignKey("GameId")]
        public int GameId { get; set; }
        public string OS { get; set; }
        public string Processor { get; set; }
        public string Graphic { get; set; }
        public string Memory { get; set; }
        public string DirectX { get; set; }
        public string Storage { get; set; }
    }
}
