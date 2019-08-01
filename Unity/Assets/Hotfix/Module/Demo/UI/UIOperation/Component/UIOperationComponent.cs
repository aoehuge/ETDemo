using ETModel;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
    [ObjectSystem]
    public class UIOperationComponentSystem : AwakeSystem<UIOperationComponent>
    {
        public override void Awake(UIOperationComponent self)
        {
            self.Awake();
        }
    }

    public class UIOperationComponent : Component
    {
        private GameObject enterMap;
        private Text text;
        public void Awake()
        {
            ReferenceCollector rc = this.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            enterMap = rc.Get<GameObject>("EnterMap");
            enterMap.GetComponent<Button>().onClick.Add(this.Jump);

            this.text = rc.Get<GameObject>("Text").GetComponent<Text>();
            this.text.text = "跳一下";
            Log.Debug("跳 按钮");
        }

        private void Jump()
        {
            Log.Debug("跳一下");
            ETModel.SessionComponent.Instance.Session.Send(new Movement_Jump());
        }
    }
}
