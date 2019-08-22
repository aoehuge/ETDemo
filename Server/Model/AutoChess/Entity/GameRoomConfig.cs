using ETHotfix;
using Google.Protobuf.Collections;

namespace ETModel
{
    public class GameRoomConfig : Entity
    {
        public RepeatedField<int> Configs;
    }
}
