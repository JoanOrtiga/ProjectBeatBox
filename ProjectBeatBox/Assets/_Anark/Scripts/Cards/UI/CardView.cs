using System;
using _Anark.Scripts.Cards.Data;
using _Anark.Scripts.Cards.Data.Settings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Anark.Scripts.Cards.UI
{
    public class CardView : MonoBehaviour
    {
        [Header("General Information")]
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private Image frontImage;
        [SerializeField] private Image backImage;
    
        protected const string ErrorText = "ERROR";
        
        public virtual void SetupCardView(Card card)
        {
            nameText.text = card.Name ?? ErrorText;
            frontImage.sprite = card.FrontImage ? card.FrontImage : frontImage.sprite;
            if(backImage != null)
                backImage.sprite = card.BackImage ? card.BackImage : backImage.sprite;
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
