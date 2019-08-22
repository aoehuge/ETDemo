using System.Threading.Tasks;
using ETModel;
namespace ETHotfix
{
    [ObjectSystem]
    public class MatchRoomComponentAwakeSystem : AwakeSystem<MatchRoomComponent>
    {
        public override void Awake(MatchRoomComponent self)
        {
            
        }
    }

    public static class MatchRoomComponentSystem
    {
        public static int JoinMatchQueue(this MatchRoomComponent matchRoomCom, long matchRoomId, User user, IResponse response)
        {
            try
            {
                if (matchRoomCom.mUserQueue.ContainsKey(user.UserId))
                {
                    response.Message = "用户已经在队列中";
                    return 1;
                }
                else
                {
                    if (!matchRoomCom.mAllQueue.ContainsKey(matchRoomId))
                    {
                        response.Message = "要加入的匹配房间不存在";
                        return 2;
                    }
                    matchRoomCom.mUserQueue.Add(user.UserId, matchRoomId);
                    matchRoomCom.mAllQueue[matchRoomId].Add(user);
                    response.Message = string.Empty;
                    return 0;
                }
            }
            catch (System.Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        private static long _TempActorId;
        private static bool _IsAI;
        public static void CheckMatchCondition(this MatchRoomComponent matchRoomComponent, long matchRoomId)
        {
            try
            {
                MatchRoomConfig matchRoomConfig = Game.Scene.GetComponent<MatchRoomConfigComponent>().GetMatchRoomInfo(matchRoomId);
                while (matchRoomComponent.mAllQueue[matchRoomId].Count >= matchRoomConfig.GameNumber)
                {
                    M2S_StartGame m2S_StartGame = new M2S_StartGame();
                    m2S_StartGame.RoomConfig = matchRoomConfig;
                    for (int i = 0; i < matchRoomConfig.GameNumber; i++)
                    {
                        _TempActorId = 0;
                        _IsAI = false;
                        if (matchRoomComponent.mAllQueue[matchRoomId][i].GetComponent<UserGateActorIdComponent>() != null)
                        {
                            _TempActorId = matchRoomComponent.mAllQueue[matchRoomId][i].GetComponent<UserGateActorIdComponent>().ActorId;
                        }
                        else
                        {
                            _IsAI = true;
                        }
                        MatchPlayerInfo matchPlayerInfo = MatchPlayerInfoFactory.Create(matchRoomComponent.mAllQueue[matchRoomId][i], _TempActorId, i, _IsAI); ;
                        m2S_StartGame.MatchPlayerInfos.Add(matchPlayerInfo);
                    }
                    matchRoomComponent.MatchStartGame(matchRoomId, matchRoomConfig.GameNumber);

                    long toyGameId = Game.Scene.GetComponent<MatchRoomConfigComponent>().GetMatchRoomInfo(matchRoomId).ToyGameId;
                    matchRoomComponent.RoomStartGame(toyGameId, m2S_StartGame);
                }
            }
            catch (System.Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        private static void MatchStartGame(this MatchRoomComponent matchRoomCom, long roomId, int number)
        {
            try
            {
                for (int i = 0; i < number; i++)
                {
                    matchRoomCom.mUserQueue.Remove(matchRoomCom.mAllQueue[roomId][0].UserId);
                    matchRoomCom.mAllQueue[roomId].RemoveAt(0);
                }
            }
            catch (System.Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        private static void RoomStartGame(this MatchRoomComponent matchRoomCom, long toyGameId, M2S_StartGame message)
        {
            try
            {
                MatchRoom matchRoom = MatchRoomFactory.CreateRandomMatchRoom(matchRoomCom.RandomRoomId(), message.MatchPlayerInfos, message.RoomConfig);
                matchRoomCom.MatchRoomDic[matchRoom.RoomId] = matchRoom;
                for (int i = 0; i < message.MatchPlayerInfos.count; i++)
                {
                    if (message.MatchPlayerInfos[i].IsAI)
                    {
                        continue;
                    }
                    matchRoomCom.UserIdInRoomDic[message.MatchPlayerInfos[i].User.UserId] = matchRoom;
                }
                message.RoomType = (int)RoomType.Match;
                Session toyGameSession = Game.Scene.GetComponent<NetInnerSessionComponent>().GetGameServerSession(toyGameId);
                message.RoomId = matchRoom.RoomId;
                toyGameSession.Send(message);
            }
            catch (System.Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }

        public static int RandomRoomId(this MatchRoomComponent matchRoomCom)
        {
            int roomId = RandomTool.Random(10000, 99999);
            while (matchRoomCom.MatchRoomDic.ContainsKey(roomId))
            {
                roomId = matchRoomCom.RandomRoomId();
            }
            Log.Info("随机生成房间号: " + roomId);
            return roomId;
        }


        public static bool IsUserInGame(this MatchRoomComponent matchRoomCom, long userId, long sessionActorId)
        {
            if (matchRoomCom.UserIdInRoomDic.ContainsKey(userId))
            {
                ActorHelp.SendActor(sessionActorId, new Actor_BeingInGame() { IsGameBeing = true });
                return true;
            }
            return false;
        }
    }

    
}
