using System;
namespace ETModel
{
    public static class RoomType
    {
        public const int Match = 1;//匹配
        public const int RoomCard = 2;//房卡
        public const int WatchVideo = 3;// 观看录像
    }

    public static class ToyGameId
    {
        public const long None = 0;
        public const long Login = 1;
        public const long Lobby = 2;
        public const long Common = 1000;
        public const long Joy = 1001;
        public const long Game = 1002;
        public const long GameVideo = 2002;
    }

    public static class RoomState
    {
        public const int None = 0;
        public const int Awat = 1;
        public const int Gaming = 2;
        public const int Ready = 3;
    }
}
