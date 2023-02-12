using System;
using System.Collections.Generic;
using _Anark.Scripts.Cards.Data;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace _ProjectBeatBox.SinglePlayer.Scripts.Match.Shop
{
    public class ShopProvider : MonoBehaviour
    {
        [Serializable] private class CardsByType
        {
            public List<Card> cards;
            public int quantity;

            public List<Card> GetCards()
            {
                var randomCards = new List<Card>();
                for (int i = 0; i < quantity; i++)
                {
                    var card = cards[Random.Range(0, cards.Count)];
                    randomCards.Add(card);
                    cards.Remove(card);
                }
                return randomCards;
            }
        }
        
        [SerializeField] private List<CardsByType> cardsByTypes;
        
        public List<Card> GetShopCards()
        {
            var cardsList = new List<Card>();
            foreach (var cardsByType in cardsByTypes)
            {
                cardsList.AddRange(cardsByType.GetCards());
            }
            return cardsList;
        }
    }
}
