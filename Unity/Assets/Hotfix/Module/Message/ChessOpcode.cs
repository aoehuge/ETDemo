using ETModel;
namespace ETHotfix
{
//开始游戏通知
	[Message(ChessOpcode.Actor_StartGame)]
	public partial class Actor_StartGame : IActorMessage {}

//玩家信息
	[Message(ChessOpcode.ChessPlayer)]
	public partial class ChessPlayer {}

//玩家操作信息
	[Message(ChessOpcode.ChessOperateInfo)]
	public partial class ChessOperateInfo {}

}
namespace ETHotfix
{
	public static partial class ChessOpcode
	{
		 public const ushort Actor_StartGame = 12001;
		 public const ushort ChessPlayer = 12002;
		 public const ushort ChessOperateInfo = 12003;
	}
}
