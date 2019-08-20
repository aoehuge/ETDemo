using System.Collections.Generic;
using ETHotfix;
namespace ETModel
{
    [ObjectSystem]
    public class MatchRoomAwake:AwakeSystem<MatchRoom>
    {
        public override void Awake(MatchRoom self)
        {
            self.Awake();
        }
    }

    public class MatchRoom : Entity
    {
        public bool IsInGame = false;
        public int RoomId { get; set; }

        public long GameServeRoomActorId { get; set; }
        public Dictionary<int, MatchPlayerInfo> PlayerInfoDic = new Dictionary<int, MatchPlayerInfo>();
        public int intData;
        public void Awake()
        {

        }

        public override void Dispose()
        {
            foreach (var playerInfo in PlayerInfoDic)
            {
                playerInfo.Value.Dispose();
            }
            PlayerInfoDic.Clear();
            RoomId = 0;
            IsInGame = false;
            GameServeRoomActorId = 0;
            base.Dispose();
        }
    }
}
