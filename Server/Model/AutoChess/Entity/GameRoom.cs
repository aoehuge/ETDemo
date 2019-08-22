using System;
using System.Collections.Generic;
using ETHotfix;
namespace ETModel
{
    [ObjectSystem]
    public class GameRoomAwakeSystem : AwakeSystem<GameRoom>
    {
        public override void Awake(GameRoom self)
        {
            self.Awake();
        }
    }

    public class GameRoom : Entity
    {
        public int MatchRoomId = 0;//匹配房间ID
        public int RoomId;//房间ID
        public int CurGameStateType = RoomState.None;//当前房间状态
        public Dictionary<int, ChessPlayer> PlayerDic = new Dictionary<int, ChessPlayer>();
        public GameRoomConfig RoomConfig;

        public bool IsHaveAI;

        public void Awake()
        {

        }
    }
}
