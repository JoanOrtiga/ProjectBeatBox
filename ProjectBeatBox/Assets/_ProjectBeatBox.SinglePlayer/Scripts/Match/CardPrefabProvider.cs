using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Anark.Scripts.Cards.UI;
using _Anark.Scripts.Logger;
using TypeReferences;
using UnityEngine;

public class CardPrefabProvider : MonoBehaviour
{
    [Serializable] private class CardPrefab
    {
        public TypeReference type;
        public CardView cardPrefab;
    }

    [SerializeField] private List<CardPrefab> cardPrefabs;

    public CardView GetCardObject(Type type)
    {
        var cardPrefab = cardPrefabs.FirstOrDefault(cardPrefab => cardPrefab.type.Type == type);
        
        if (cardPrefab == null)
        {
            ConsoleLog.LogError("Card prefab should not be null", ConsoleLog.Tags.InMatch);
        }
        
        return cardPrefab?.cardPrefab;
    }
}
