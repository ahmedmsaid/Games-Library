using Games_Library.Models;
namespace Games_Library.ViewModel
{
    public class GameSysReq
    {
        public int SysReqId { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public List<Game> Games { get; set; }
        public SysReq SysReq { get; set; }
    }
}
