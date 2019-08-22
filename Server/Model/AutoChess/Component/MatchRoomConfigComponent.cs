using System.Collections.Generic;
using ETHotfix;
namespace ETModel
{
    [ObjectSystem]
    public class MatchRoomConfigComponentAwakeSystem : AwakeSystem<MatchRoomConfigComponent>
    {
        public override void Awake(MatchRoomConfigComponent self)
        {
            self.Awake();
        }
    }
    public class MatchRoomConfigComponent:Component
    {
        private readonly Dictionary<long, List<MatchRoomConfig>> mMatchRoomConfigs = new Dictionary<long, List<MatchRoomConfig>>();//游戏ID对应匹配房间配置
        private readonly Dictionary<long, MatchRoomConfig> mMatchIdInRoomConfigs = new Dictionary<long, MatchRoomConfig>();//匹配房间Id对应匹配配置
        private DBProxyComponent dBProxyCom;

        public void Awake()
        {

        }

        public MatchRoomConfig GetMatchRoomInfo(long RoomId)
        {
            MatchRoomConfig matchRoomConfig;
            if (mMatchIdInRoomConfigs.TryGetValue(RoomId, out matchRoomConfig))
            {

            }
            return matchRoomConfig;
        }
    }
}
