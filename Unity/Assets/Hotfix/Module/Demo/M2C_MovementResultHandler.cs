using ETModel;

namespace ETHotfix
{
    [MessageHandler]
    public class M2CMovementResultHandler : AMHandler<M2C_MovementResult>
    {
        protected override async ETTask Run(ETModel.Session session, M2C_MovementResult message)
        {
            Unit unit = ETModel.Game.Scene.GetComponent<UnitComponent>().Get(message.Id);
            unit.GetComponent<AnimatorComponent>().SetFloatValue("Speed", 0f);

            unit.GetComponent<AnimatorComponent>().SetIntValue("state", 3);
			ETModel.Log.Debug("跳的结果");
            await ETTask.CompletedTask;
        }
    }
}