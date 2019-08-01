using ETModel;

namespace ETHotfix
{
    [ActorMessageHandler(AppType.Map)]
    public class Movement_JumpHandler : AMActorLocationHandler<Unit, Movement_Jump>
    {
        protected override async ETTask Run(Unit entity, Movement_Jump message)
        {
            M2C_MovementResult m2C_MovementResult = new M2C_MovementResult();
            m2C_MovementResult.Id = entity.Id;
            MessageHelper.Broadcast(m2C_MovementResult);
            await ETTask.CompletedTask;
        }
    }
}