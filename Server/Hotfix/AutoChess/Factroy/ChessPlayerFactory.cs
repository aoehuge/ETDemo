using System.Collections.Generic;
using System.Threading.Tasks;
using ETModel;
namespace ETHotfix
{
    public static class ChessPlayerFactory
    {
        private static List<ChessPlayer> _playerPool = new List<ChessPlayer>();
        public static async Task<ChessPlayer> Create(MatchPlayerInfo matchPlayerInfo, GameRoom gameRoom)
        {
            try
            {
                ChessPlayer player = ComponentFactory.Create<ChessPlayer>();

                await player.AddComponent<MailBoxComponent>().AddLocation();
                return player;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        public static ChessPlayer CopySerialize(ChessPlayer player)
        {
            ChessPlayer newPlayer;
            if (_playerPool.Count > 0)
            {
                newPlayer = _playerPool[0];
                _playerPool.RemoveAt(0);
            }
            else
            {
                newPlayer = ComponentFactory.Create<ChessPlayer>();
            }
            newPlayer.SeatIndex = player.SeatIndex;
            newPlayer.User = player.User;
            newPlayer.PlayCards = player.PlayCards;
            newPlayer.OperateInfos = player.OperateInfos;
            newPlayer.HandCards = player.HandCards;
            newPlayer.NowHP = player.NowHP;
            newPlayer.WinCount = player.WinCount;
            newPlayer.DefeatCount = player.DefeatCount;
            
            return newPlayer;
        }

        public static void DisposeSerializePlayer(ChessPlayer player)
        {
            _playerPool.Add(player);
        }
    }
}
