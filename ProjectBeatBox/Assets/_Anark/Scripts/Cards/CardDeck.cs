using System.Collections.Generic;
using _Anark.Scripts.Cards.Data;

namespace _Anark.Scripts.Cards
{
    public class CardDeck
    {
        private readonly List<Card> _deck;
        public List<Card> GetCardsFromDeck => _deck;
        
        public CardDeck()
        {
            _deck = new List<Card>();
        }

        public void AddCard(Card card)
        {
            _deck.Add(card);
        }
        
        public void RemoveCard(Card card)
        {
            _deck.Remove(card);
        }

        public void SetNewDeck(List<Card> newDeck)
        {
            _deck.Clear();

            foreach (var card in newDeck)
            {
                AddCard(card);
            }
        }
    }
}
