using System;
using System.Collections.Generic;
using _Anark.Scripts.Cards.Data;
using _Anark.Scripts.Logger;
using TypeReferences;
using UnityEngine;
using UnityEngine.Serialization;

public class ShopViewUI : MonoBehaviour
{
    [Serializable] private class AnchorCardsByType
    {
        public TypeReference card;
        public Transform[] cardAnchors;

        private int _currentCardAnchor = 0;
        
        public Transform GetAvailableAnchor()
        {
            if (_currentCardAnchor > cardAnchors.Length)
            {
                ConsoleLog.LogError("Too much cards for given card anchors", ConsoleLog.Tags.InMatch);
                return null;
            }
            
            var anchor = cardAnchors[_currentCardAnchor];
            _currentCardAnchor++;
            return anchor;
        }
    }

    [Header("References")] [SerializeField]
    private CardPrefabProvider cardPrefabProvider;
    
    [Header("Settings")]
    [SerializeField] private List<AnchorCardsByType> shopItems;
    [SerializeField] private GameObject shopUI;

    public void Show(List<Card> cards)
    {
        FillCards(cards);
        shopUI.SetActive(true);
    }
    
    public void Hide()
    {
        shopUI.SetActive(false);
    }

    private void FillCards(List<Card> cards)
    {
        foreach (var card in cards)
        {
            SetCard(card);
        }
    }

    private void SetCard(Card card)
    {
        foreach (var shopItem in shopItems)
        {
            if (shopItem.card.Type != card.GetType())
                continue;

            var cardPrefab = cardPrefabProvider.GetCardObject(card.GetType());
            var cardView = Instantiate(cardPrefab, shopItem.GetAvailableAnchor(), false);
            cardView.SetupCardView(card);
            return;
        }
        
        ConsoleLog.LogError("No type found for this card", ConsoleLog.Tags.InMatch);
    }


}
