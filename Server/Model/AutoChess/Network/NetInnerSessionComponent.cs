using System;
using System.Net;
using ETHotfix;
namespace ETModel
{
    public class NetInnerSessionComponent : Component
    {
        public Session Get(AppType appType)
        {
            try
            {
                StartConfig startConfig;
                switch (appType)
                {
                    case AppType.Realm:
                        startConfig = StartConfigComponent.Instance.RealmConfig;
                        break;
                    case AppType.DB:
                        startConfig = StartConfigComponent.Instance.DBConfig;
                        break;
                    case AppType.Location:
                        startConfig = StartConfigComponent.Instance.LocationConfig;
                        break;
                    case AppType.Match:
                        startConfig = StartConfigComponent.Instance.MatchConfig;
                        break;
                    case AppType.Lobby:
                        startConfig = StartConfigComponent.Instance.LobbyConfig;
                        break;
                    case AppType.User:
                        startConfig = StartConfigComponent.Instance.UserConfig;
                        break;
                    default:
                        throw new Exception("单服没有这个appType:" + appType);
                }
                return GetSession(startConfig);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        public Session Get(AppType appType, int index)
        {
            try
            {
                StartConfig startConfig;
                switch (appType)
                {
                    case AppType.Gate:
                        startConfig = StartConfigComponent.Instance.GateConfigs[index];
                        break;
                    case AppType.Map:
                        startConfig = StartConfigComponent.Instance.MapConfigs[index];
                        break;
                    default:
                        throw new Exception("多服没有这个appType: " + appType);
                }
                return GetSession(startConfig);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        public Session GetGameServerSession(long toyGameId)
        {
            try
            {
                StartConfig startConfig;
                switch (toyGameId)
                {
                    case ToyGameId.Game:
                        startConfig = StartConfigComponent.Instance.GameConfigs[0];
                        break;
                    default:
                        throw new Exception("没有这种类型游戏服务器" + toyGameId);
                }
                return GetSession(startConfig);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        public Session GetSession(StartConfig startConfig)
        {
            IPEndPoint innerAddress = startConfig.GetComponent<InnerConfig>().IPEndPoint;
            Session session = Game.Scene.GetComponent<NetInnerComponent>().Get(innerAddress);
            return session;
        }
    }
}
