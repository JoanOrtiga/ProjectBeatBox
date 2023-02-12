using System.Linq;
using _Anark.Scripts.Cards.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;

namespace _Anark.Scripts.Cards.UI
{
    public class CharacterCardView : CardView
    {
        [Header("Cost")]
        [Header("Character Card")]
        [SerializeField] private CostCardElementView[] costElements;

        [Header("Stats")] 
        [SerializeField] private StatCardElementView[] statElements;
        
        [Header("Resources")] 
        [SerializeField] private ResourceCardElementView[] resourceElements;

        [Header("Team")] 
        [SerializeField] private SpriteRenderer teamIcon;
        [SerializeField] private SpriteRenderer teamBackground;
        [SerializeField] private TextMeshProUGUI passiveDescription;
        
        public override void SetupCardView(Card card)
        {
            base.SetupCardView(card);

            var characterCard = card as CharacterCard;
            Assert.IsNotNull(characterCard, $"Card should be type {nameof(CharacterCard)}");
            
            FillStatsData(characterCard);
            FillCostData(characterCard);
            FillTeamData(characterCard);
            FillPassivesData(characterCard);
            FillResourcesData(characterCard);
        }

        private void FillStatsData(CharacterCard characterCard)
        {
            foreach (var statElement in statElements)
            {
                var statStatus = characterCard.Status.First(cardStatStatus => cardStatStatus.StatData.Id == statElement.StatData.Id);
                if(statElement.NameText != null)
                    statElement.NameText.text = statStatus.StatData.Name;
                statElement.AmountText.text = statStatus.Amount.ToString();
            }
        }

        private void FillResourcesData(CharacterCard characterCard)
        {
            foreach (var resourceElement in resourceElements)
            {
                var cardResource = characterCard.Resources.First(cardResource =>  cardResource.ResourceData.Id == resourceElement.ResourceData.Id);
                if(resourceElement.NameText != null)
                    resourceElement.NameText.text = cardResource.ResourceData.Name;
                resourceElement.AmountText.text = cardResource.Amount.ToString();
            }
        }

        private void FillCostData(CharacterCard characterCard)
        {
            foreach (var costElement in costElements)
            {
                var cardCost = characterCard.Cost.First(cardCost => cardCost.CardResource.Id == costElement.CostData.CardResource.Id);
                if(costElement.NameText != null)
                    costElement.NameText.text = cardCost.CardResource.Name;
                costElement.AmountText.text = cardCost.Amount.ToString();
            }
        }

        private void FillTeamData(CharacterCard characterCard)
        {
            teamIcon.sprite = characterCard.Team.Icon ? characterCard.Team.Icon : teamIcon.sprite;
        }

        private void FillPassivesData(CharacterCard characterCard)
        {
            passiveDescription.text = string.Empty;
            foreach (var cardPassive in characterCard.GetCardPassives())
            {
                passiveDescription.text += cardPassive.Description ?? string.Empty;
            }
        }
    }
}