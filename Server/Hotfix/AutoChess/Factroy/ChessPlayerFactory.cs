using System.Threading.Tasks;
using ETModel;
namespace ETHotfix
{
    public static class GamePlayerFactory
    {
        public static async Task<ChessPlayer> Create(MatchPlayerInfo matchPlayerInfo, GameRoom gameRoom)
        {
            try
            {
                ChessPlayer player = ComponentFactory.Create<ChessPlayer>();

                await player.AddComponent<MailBoxComponent>().AddLocation();
                return player;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
    }
}
