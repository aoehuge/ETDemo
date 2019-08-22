using System.Collections.Generic;
using ETModel;
namespace ETHotfix
{
    [ObjectSystem]
    public class ChessPlayerAwakeSystem : AwakeSystem<ChessPlayer>
    {
        public override void Awake(ChessPlayer self)
        {
            self.Awake();
        }
    }
    public partial class ChessPlayer : Entity
    {
        public GameRoom GameRoom;
        public readonly Dictionary<int, Card> CardsDic = new Dictionary<int, Card>();
        public bool IsAI; //是否是机器人

        public void Awake()
        {
           
        }
    }
}
