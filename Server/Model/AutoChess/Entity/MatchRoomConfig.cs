using ETModel;
namespace ETHotfix
{
    public partial class MatchRoomConfig : Entity
    {
        public override void Dispose()
        {
            ToyGameId = 0;
            GameNumber = 0;
            RoomConfigs = null;
            base.Dispose();
        }
    }
}
