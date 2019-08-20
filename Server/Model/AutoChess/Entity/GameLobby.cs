
namespace ETModel
{
    [ObjectSystem]
    public class GameLobbyAwakeSystem : AwakeSystem<GameLobby>
    {
        public override void Awake(GameLobby self)
        {
            self.Awake();
        }
    }

    public class GameLobby : Entity
    {
        public DBProxyComponent dBProxyComponent;
        public static GameLobby Ins;

        public void Awake()
        {
            Ins = this;

        }
    }
}