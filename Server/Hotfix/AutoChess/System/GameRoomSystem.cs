using System;
using ETModel;
using Google.Protobuf.Collections;

namespace ETHotfix
{
    public static class GameRoomSystem
    {
        public static void StarGame(this GameRoom gameRoom)
        {
            Actor_StartGame actor_StartGame = new Actor_StartGame();
            actor_StartGame.RoomConfigs = gameRoom.RoomConfig.Configs;
            actor_StartGame.RoomId = gameRoom.RoomId;
            foreach (var player in gameRoom.PlayerDic.Values)
            {
                actor_StartGame.PlayerInfos.Add(ChessPlayerFactory.CopySerialize(player));
            }

            foreach (var player in gameRoom.PlayerDic)
            {
                player.Value.StartGame(actor_StartGame);
            }
            
            foreach (var player in actor_StartGame.PlayerInfos)
            {
                ChessPlayerFactory.DisposeSerializePlayer(player);
            }
        }

        public static void SmallStartGame(this GameRoom gameRoom)
        {
            gameRoom.CurGameStateType = RoomState.Gaming;

        }

        public static async void DistributeCard(this GameRoom gameRoom)
        {
            RepeatedField<RepeatedField<int>> cards;
            if (gameRoom.IsHaveAI)
            {
                //cards =  
            }
        }

    }
}
