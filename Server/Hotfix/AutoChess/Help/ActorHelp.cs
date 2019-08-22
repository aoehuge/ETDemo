using ETModel;
namespace ETHotfix
{
    public static class ActorHelp
    {
        public static void SendActor(long actorId, IActorMessage message)
        {
            if (actorId == 0)
            {
                return;
            }

            ActorMessageSender actorSender = Game.Scene.GetComponent<ActorMessageSenderComponent>().Get(actorId);
            actorSender.Send(message);
        }
    }
}
