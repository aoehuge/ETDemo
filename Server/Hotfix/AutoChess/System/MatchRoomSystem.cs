using System;
using ETModel;
namespace ETHotfix
{
    public static class MatchRoomSystem
    {
        public static void GameServerStartGame(this MatchRoom matchRoom, long serverRoomAId)
        {
            matchRoom.IsInGame = true;
            matchRoom.GameServeRoomActorId = serverRoomAId;
        }
    }
}
