using System.Threading.Tasks;
using ETModel;
namespace ETHotfix
{
    public static class GameRoomComponentSystem
    {
        public static async Task<GameRoom> StartGame(this GameRoomComponent gameRoomComm, M2S_StartGame m2S_StartGame)
        {
            try
            {
                GameRoom gameRoom = await GameRoomFactory.Create(m2S_StartGame);
                return gameRoom;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        public static void RemoveRoom(this GameRoomComponent gameRoomCom, int roomId)
        {
            if (gameRoomCom.gameRoomDic.ContainsKey(roomId))
            {
                gameRoomCom.gameRoomDic.Remove(roomId);
                gameRoomCom.RoomIds.Remove(roomId);
            }
        }
    }
}
