using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ETModel
{
    public class CardComponent : Component
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private readonly Dictionary<long, Card> idCards = new Dictionary<long, Card>();

        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }

            base.Dispose();

            foreach (var card in this.idCards.Values)
            {
                card.Dispose();
            }
            this.idCards.Clear();
        }

        public void Add(Card card)
        {
            this.idCards.Add(card.Id, card);
        }

        public Card Get(long id)
        {
            this.idCards.TryGetValue(id, out Card card);
            return card;
        }

        public void Remove(long id)
        {
            Card card;
            this.idCards.TryGetValue(id, out card);
            this.idCards.Remove(id);
            card?.Dispose();
        }

        public void RemoveNoDispose(long id)
        {
            this.idCards.Remove(id);
        }

        public int Count
        {
            get
            {
                return this.idCards.Count;
            }
        }

        public Card[] GetAll()
        {
            return this.idCards.Values.ToArray();
        }
    }
}