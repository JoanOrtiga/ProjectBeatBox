using System;
using System.Collections.Generic;
using _Anark.Scripts.Cards.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _Anark.Scripts.Game.CardView
{
    public class CurrentHandDisplay : MonoBehaviour
    {
        [SerializeField] private Cards.UI.CardView prefabCardView;
        [SerializeField] private Transform[] cardAnchorPoints;

        private void DisplayCards(List<Card> cards)
        {
            var index = 0;
            foreach (var card in cards)
            {
                var cardView = Instantiate(prefabCardView, cardAnchorPoints[index]);
                cardView.SetupCardView(card);
                index++;
            }    
        }
    }
}
