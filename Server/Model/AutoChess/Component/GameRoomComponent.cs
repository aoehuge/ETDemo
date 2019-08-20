using System.Collections.Generic;
using ETHotfix;
namespace ETModel
{
    [ObjectSystem]
    public class GameRoomComponentAwakeSystem : AwakeSystem<GameRoomComponent>
    {
        public override void Awake(GameRoomComponent self)
        {
            self.Awake();
        }
    }

    public class GameRoomComponent : Component
    {
        public static GameRoomComponent Ins { get; private set; }
        public readonly List<int> RoomIds = new List<int>();
        public readonly Dictionary<int, GameRoom> gameRoomDic = new Dictionary<int, GameRoom>();
        public DBProxyComponent dBProxyCom;


        public void Awake()
        {

        }
    }
}
