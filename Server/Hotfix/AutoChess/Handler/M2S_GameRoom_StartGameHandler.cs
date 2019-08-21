using System;
using ETModel;
namespace ETHotfix
{
    [MessageHandler(AppType.GameRoom)]
    public class M2S_GameRoom_StartGameHandler : AMHandler<M2S_StartGame>
    {
        protected override async ETTask Run(Session session, M2S_StartGame message)
        {
            S2M_StartGame response = new S2M_StartGame();
            GameRoom gameRoom = await Game.Scene.GetComponent<GameRoomComponent>().StartGame(message);
            response.RoomId = message.RoomId;
            response.RoomActorId = gameRoom.RoomId;
            session.Send(response);
        }
    }
}
