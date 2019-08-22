using ETModel;
using Google.Protobuf.Collections;
namespace ETHotfix
{
    public static class MatchRoomFactory
    {
        public static MatchRoom CreateRandomMatchRoom(int roomId, RepeatedField<MatchPlayerInfo> matchPlayerInfos, MatchRoomConfig config)
        {
            try
            {
                MatchRoom matchRoom = ComponentFactory.Create<MatchRoom>();
                matchRoom.RoomId = roomId;
                matchRoom.RoomConfig = config;

                for (int i = 0; i < matchPlayerInfos.Count; i++)
                {
                    matchRoom.PlayerInfoDic[matchPlayerInfos[i].SeatIndex] = matchPlayerInfos[i];
                }
                return matchRoom;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
    }

}
