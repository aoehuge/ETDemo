namespace ETModel
{
	public static partial class MatchOpcode
	{
		 public const ushort C2M_StartMatch = 19001;
		 public const ushort M2C_StartMatch = 19002;
		 public const ushort C2M_CreateRoom = 19003;
		 public const ushort M2C_CreateRoom = 19004;
		 public const ushort C2M_JoinRoom = 19005;
		 public const ushort M2C_JoinRoom = 19006;
		 public const ushort C2M_OutRoom = 19007;
		 public const ushort M2C_OutRoom = 19008;
		 public const ushort Actor_OtherJoinRoom = 19009;
		 public const ushort Actor_OtherOutRoom = 19010;
		 public const ushort Actor_PauseRoomGame = 19011;
		 public const ushort Actor_RoomDissolve = 19012;
		 public const ushort S2M_RoomDissolve = 19013;
		 public const ushort Actor_VoteDissolveSelect = 19014;
		 public const ushort Actor_VoteDissolveRoomResult = 19015;
		 public const ushort VoteInfo = 19016;
		 public const ushort C2M_UserChat = 19017;
		 public const ushort M2C_UserChat = 19018;
		 public const ushort Actor_UserChatInfo = 19019;
		 public const ushort ChatInfo = 19020;
		 public const ushort M2S_StartGame = 19021;
		 public const ushort S2M_StartGame = 19022;
		 public const ushort C2M_GetFriendsCircleRoomList = 19023;
		 public const ushort M2C_GetFriendsCircleRoomList = 19024;
		 public const ushort Actor_BeingInGame = 19025;
		 public const ushort C2M_GetReconnectionRoomInfo = 19026;
		 public const ushort M2C_GetReconnectionRoomInfo = 19027;
		 public const ushort Actor_UserRequestReconnectionRoom = 19028;
	}
}
