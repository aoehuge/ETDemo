using System.Collections.Generic;

namespace ETModel
{
    [ObjectSystem]
    public class MatchRoomComponentAwakeSystem : AwakeSystem<MatchRoomComponent>
    {
        public override void Awake(MatchRoomComponent self)
        {
            self.Awake();
        }
    }

    public class MatchRoomComponent : Component
    {
        public static MatchRoomComponent Ins { get; private set; }

        public Dictionary<long, long> mUserQueue = new Dictionary<long, long>();//用户的ID所在对应的匹配队列
        public Dictionary<long, List<User>> mAllQueue = new Dictionary<long, List<User>>();//每个匹配队列ID里对应的玩家列表

        public Dictionary<int, MatchRoom> MatchRoomDic = new Dictionary<int, MatchRoom>();//房间ID和对应的房间
        public Dictionary<long, MatchRoom> UserIdInRoomDic = new Dictionary<long, MatchRoom>(); //用户ID对应房间
        

        public void Awake()
        {
            Ins = this;

        }
    }
}