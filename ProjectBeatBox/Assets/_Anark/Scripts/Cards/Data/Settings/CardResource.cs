using System;
using UnityEngine;

namespace _Anark.Scripts.Cards.Data.Settings
{
    [CreateAssetMenu(menuName = "Card/Settings/Resource", fileName = "CardResource")]
    public class CardResource : ScriptableObject
    {
        [field: SerializeField] public string Id { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Sprite icon { get; private set; }
    }
    
    [Serializable]
    public class CardResourcesStatus
    {
        [field: SerializeField] public CardResource ResourceData { get; private set; }
        [field: SerializeField] public int Amount { get; private set; }
    }
}