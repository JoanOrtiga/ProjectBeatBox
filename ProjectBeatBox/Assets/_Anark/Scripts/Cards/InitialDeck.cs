using System;
using System.Collections.Generic;
using _Anark.Scripts.Cards.Data;
using UnityEngine;

namespace _Anark.Scripts.Cards
{
    [CreateAssetMenu(menuName = "Card/Deck", fileName = "Deck")]
    public class InitialDeck : ScriptableObject
    {
        [field: SerializeField] public InitialByTypeDeck[] InitialByTypeDecks { get; private set; }
    }

    [Serializable]
    public struct InitialByTypeDeck
    {
        [field: SerializeField] public string Id { get; private set; }
        [field: SerializeField] public Card[] Cards { get; private set; }
        [field: SerializeField] public int MinimumCards { get; private set; }
        [field: SerializeField] public float Chance { get; private set; }
    }
}