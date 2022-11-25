using System;
using _Anark.Scripts.Cards.Data;
using _Anark.Scripts.Cards.Data.Settings;
using TMPro;
using UnityEngine;

namespace _Anark.Scripts.Cards.UI
{
    public class CardView : MonoBehaviour
    {
        [Header("General Information")]
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private SpriteRenderer frontImage;
        [SerializeField] private SpriteRenderer backImage;
    
        public virtual void SetupCardView(Card card)
        {
            nameText.text = card.Name;
            frontImage.sprite = card.FrontImage;
            backImage.sprite = card.BackImage;
        }
        
        [Serializable]
        public struct StatCardElementView
        {
            [field: SerializeField] public CardStat StatData { get; private set; }
            [field: SerializeField] public TextMeshProUGUI NameText { get; private set; }
            [field: SerializeField] public TextMeshProUGUI AmountText { get; private set; }
        }
        
        [Serializable]
        public struct CostCardElementView
        {
            [field: SerializeField] public CardCost CostData { get; private set; }
            [field: SerializeField] public TextMeshProUGUI NameText { get; private set; } 
            [field: SerializeField] public TextMeshProUGUI AmountText { get; private set; }
        }
        
        [Serializable]
        public struct ResourceCardElementView
        {
            [field: SerializeField] public CardResource ResourceData { get; private set; }
            [field: SerializeField] public TextMeshProUGUI NameText { get; private set; } 
            [field: SerializeField] public TextMeshProUGUI AmountText { get; private set; }
        }
    }
}