using System;
using ETModel;
namespace ETHotfix
{
    public static class ChessPlayerSystem
    {
        public static void StartGame(this ChessPlayer chessPlayer, Actor_StartGame actor_StartGame)
        {
            chessPlayer.SendGateStartGame();
            chessPlayer.SendMessageUser(actor_StartGame);
        }

        public static void SendGateStartGame(this ChessPlayer chessPlayer)
        {
            chessPlayer.SendMessageUser(new Actor_UserStartGame { SessionActorId = chessPlayer.Id });
        }

        public static void SendMessageUser(this ChessPlayer chessPlayer, IActorMessage message)
        {
            if (chessPlayer.IsAI)
            {
                return;
            }
            if (chessPlayer.User != null)
            {
                chessPlayer.User.SendSessionClientActor(message);
            }
        }
    }
}
