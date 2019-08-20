using UnityEngine;

namespace ETModel
{
    public enum CardType
    {
        entity,
        show
    }

    public class CardAwakeSystem : AwakeSystem<Card, CardType>
    {
        public override void Awake(Card self, CardType a)
        {
            self.Awake(a);
        }
    }

    public partial class Card : Entity
    {
        public CardType CardType { get; private set; }

        public Vector3 Position { get; set; }

        public void Awake(CardType cardType)
        {
            this.CardType = cardType;
        }

        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }
            base.Dispose();
        }
    }
}