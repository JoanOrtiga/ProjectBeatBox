using System;
using UnityEngine;

namespace _ProjectBeatBox.GameElements.Cards.Scripts.Settings
{
    [Serializable]
    public class CardCost
    {
        [field: SerializeField] public CardResource CardResource { get; private set; }
        [field: SerializeField] public int Amount { get; private set; }
    }
}