using ETModel;
namespace ETHotfix
{
    [MessageHandler(AppType.GameRoom)]
    public class M2S_GameRoom_StartGameHandler : AMHandler<M2S_StartGame>
    {
        protected override async void Run(Session session, M2S_StartGame message)
        {
            S2M_StartGame response = new S2M_StartGame();
            try
            {
                Log.Info("游戏房间收到开始游戏");
                GameRoom gameRoom = await Game.Scene.GetComponent<GameRoomComponent>().StartGame(message);
                response.RoomId = message.RoomId;
                response.RoomActorId = gameRoom.Id;
                session.Send(response);

            }
            catch (System.Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
    }
}
