using System;
using ETModel;
namespace ETHotfix
{
    public class G2M_StartMatchHandler : AMRpcHandler<C2M_StartMatch, M2C_StartMatch>
    {
        protected override async ETTask Run(Session session, C2M_StartMatch request, M2C_StartMatch response, Action reply)
        {
            if (MatchRoomComponent.Ins.IsUserInGame(request.UserId,request.SessionActorId))
            {
                return;
            }
            request.User.AddComponent<UserGateActorIdComponent>().ActorId = request.SessionActorId;
            response.Error = Game.Scene.GetComponent<MatchRoomComponent>().JoinMatchQueue(request.MatchRoomId, request.User, response);
            reply();
            Game.Scene.GetComponent<MatchRoomComponent>().CheckMatchCondition(request.MatchRoomId);
            await ETTask.CompletedTask;
        }
    }
}
