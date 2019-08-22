using System;
using ETModel;
namespace ETHotfix
{
    [MessageHandler(AppType.Match)]
    public class S2M_GameRoom_StartGameHandler : AMHandler<S2M_StartGame>
    {
        protected override async ETTask Run(Session session, S2M_StartGame message)
        {
            Game.Scene.GetComponent<MatchRoomComponent>().GetRoom(message.RoomId).GameServerStartGame(message.RoomActorId);
            await ETTask.CompletedTask;
        }
    }
}
