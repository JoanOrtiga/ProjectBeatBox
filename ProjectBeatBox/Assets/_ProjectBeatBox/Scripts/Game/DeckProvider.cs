using System;
using System.Collections.Generic;
using System.Linq;
using _Anark.Scripts.Cards;
using _Anark.Scripts.Cards.Data;
using Unity.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _ProjectBeatBox.GameElements.Game
{
    public class DeckProvider : MonoBehaviour
    {
        [SerializeField] private InitialDeckSettings initialDeckSettings;

        public CardDeck CreateCardDeck()
        {
            var cardDeck = new CardDeck();
            foreach (var initialByTypeDeck in initialDeckSettings.InitialByTypeDecks)
            {
                var availableCards = new List<Card>(initialByTypeDeck.Cards);

                for (int i = 0; i < initialByTypeDeck.MinimumCards; i++)
                {
                    var card = availableCards[Random.Range(0, availableCards.Count - 1)];
                    cardDeck.AddCard(card);
                    availableCards.Remove(card);
                }
            }
            
            return cardDeck;
        }

        public static List<FixedString32Bytes> CardDeckToString(CardDeck cardDeck)
        {
            List<FixedString32Bytes> cardIds = new List<FixedString32Bytes>();
            foreach (var card in cardDeck.GetCardsFromDeck)
            {
                cardIds.Add(card.Id);
            }

            return cardIds;
        }
    }
}