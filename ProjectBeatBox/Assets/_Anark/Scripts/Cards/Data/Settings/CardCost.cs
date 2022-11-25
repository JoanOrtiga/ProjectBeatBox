using System;
using UnityEngine;

namespace _Anark.Scripts.Cards.Data.Settings
{
    [Serializable]
    public class CardCost
    {
        [field: SerializeField] public CardResource CardResource { get; private set; }
        [field: SerializeField] public int Amount { get; private set; }
    }
}