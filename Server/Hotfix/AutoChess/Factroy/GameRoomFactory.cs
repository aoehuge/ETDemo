using ETModel;
using System.Threading.Tasks;

namespace ETHotfix
{
    public static class GameRoomFactory
    {
        public static async Task<GameRoom> Create(M2S_StartGame m2S_StartGame)
        {
            try
            {
                GameRoom gameRoom = ComponentFactory.Create<GameRoom>();

                //添加玩家
                foreach (var playerInfo in m2S_StartGame.MatchPlayerInfos)
                {
                    gameRoom.PlayerDic[playerInfo.SeatIndex] = await ChessPlayerFactory.Create(playerInfo, gameRoom);
                }

                await gameRoom.AddComponent<MailBoxComponent>().AddLocation();
                return gameRoom;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
    }
}
