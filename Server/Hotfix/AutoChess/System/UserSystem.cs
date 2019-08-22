using ETModel;
namespace ETHotfix
{
    public static class UserSystem
    {
        public static void SendSessionClientActor(this User user, IActorMessage message)
        {
            if (user.GetComponent<UserGateActorIdComponent>() != null)
            {
                long actorId = user.GetComponent<UserGateActorIdComponent>().ActorId;
                ActorHelp.SendActor(actorId, message);
            }
        }
    }
}
