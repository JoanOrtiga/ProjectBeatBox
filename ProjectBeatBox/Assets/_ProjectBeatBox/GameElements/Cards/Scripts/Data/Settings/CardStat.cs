using System;
using UnityEngine;

namespace _ProjectBeatBox.GameElements.Cards.Scripts.Settings
{
    [CreateAssetMenu(menuName = "Card/Settings/Stat", fileName = "CardStat")]
    public class CardStat : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Id { get; private set; }
    }
    
    [Serializable]
    public class CardStatStatus
    {
        [field: SerializeField] public CardStat StatData { get; private set; }
        [field: SerializeField] public int Amount { get; private set; }
    }
}