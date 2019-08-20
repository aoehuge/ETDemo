using System;
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
        public void Awake()
        {

        }
    }
}
