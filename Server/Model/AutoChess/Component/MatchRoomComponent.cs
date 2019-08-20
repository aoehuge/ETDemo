using System.Collections.Generic;

namespace ETModel
{
    [ObjectSystem]
    public class GameMatchComponentAwakeSystem : AwakeSystem<GameMatchComponent>
    {
        public override void Awake(GameMatchComponent self)
        {
            self.Awake();
        }
    }

    public class GameMatchComponent : Component
    {
        public Dictionary<long, long> mUserQueue = new Dictionary<long, long>();
        public Dictionary<long, List<User>> mAllQueue = new Dictionary<long, List<User>>();

        public void Awake()
        {
            
        }
    }
}