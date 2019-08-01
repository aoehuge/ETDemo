using ETModel;
using UnityEngine;

namespace ETHotfix
{
    [Event(EventIdType.EnterMapFinish)]
    public class UIOperationSystem : AEvent
    {
        public override void Run()
        {
            UI ui = UIOperationFactory.Create();
            Game.Scene.GetComponent<UIComponent>().Add(ui);
        }
    }

    public static class UIOperationFactory
    {
        public static UI Create()
        {
            try
            {
                ResourcesComponent resourcesComponent = ETModel.Game.Scene.GetComponent<ResourcesComponent>();
                resourcesComponent.LoadBundle(UIType.UILobby.StringToAB());
                GameObject bundleGameObject = (GameObject)resourcesComponent.GetAsset(UIType.UILobby.StringToAB(), UIType.UILobby);
                GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject);
                UI ui = ComponentFactory.Create<UI, string, GameObject>(UIType.UILobby, gameObject, false);

                ui.AddComponent <UIOperationComponent>();
                return ui;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex);
                return null;
            }
        }
    }
}
