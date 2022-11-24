using TMPro;
using UnityEngine;

namespace _ProjectBeatBox.GameElements.Cards.Scripts
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
    }
}
