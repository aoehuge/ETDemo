using System.Collections.Generic;
using ETHotfix;
namespace ETModel
{
    [ObjectSystem]
    public class ChessPlayerAwakeSystem : AwakeSystem<ChessPlayer>
    {
        public override void Awake(ChessPlayer self)
        {
            self.Awake();
        }
    }
    public class ChessPlayer : Entity
    {
        public GameRoom GameRoom;
        public readonly Dictionary<int, Card> CardsDic = new Dictionary<int, Card>();
        
        public void Awake()
        {
           
        }
    }
}
