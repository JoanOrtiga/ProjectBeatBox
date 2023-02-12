using System.Linq;
using _Anark.Scripts.Cards.Data;
using UnityEngine;
using UnityEngine.Assertions;

namespace _Anark.Scripts.Cards.UI
{
    public class ObjectCardView : CardView
    {
        [Header("Cost")]
        [Header("Character Card")]
        [SerializeField] private CostCardElementView[] costElements;

        [Header("Stats")] 
        [SerializeField] private StatCardElementView[] statElements;
        
        [Header("Resources")] 
        [SerializeField] private ResourceCardElementView[] resourceElements;

        public override void SetupCardView(Card card)
        {
            base.SetupCardView(card);

            var characterCard = card as ObjectCard;
            Assert.IsNotNull(characterCard, $"Card should be type {nameof(ObjectCard)}");
            
            FillStatsData(characterCard);
            FillCostData(characterCard);
            FillResourcesData(characterCard);
        }

        private void FillStatsData(ObjectCard characterCard)
        {
            foreach (var statElement in statElements)
            {
                var statStatus = characterCard.Status.First(cardStatStatus => cardStatStatus.StatData.Id == statElement.StatData.Id);
                if(statElement.NameText != null)
                    statElement.NameText.text = statStatus.StatData.Name;
                statElement.AmountText.text = statStatus.Amount.ToString();
            }
        }

        private void FillResourcesData(ObjectCard characterCard)
        {
            foreach (var resourceElement in resourceElements)
            {
                var cardResource = characterCard.Resources.First(cardResource =>  cardResource.ResourceData.Id == resourceElement.ResourceData.Id);
                if(resourceElement.NameText != null)
                    resourceElement.NameText.text = cardResource.ResourceData.Name;
                resourceElement.AmountText.text = cardResource.Amount.ToString();
            }
        }

        private void FillCostData(ObjectCard characterCard)
        {
            foreach (var costElement in costElements)
            {
                var cardCost = characterCard.Cost.First(cardCost => cardCost.CardResource.Id == costElement.CostData.CardResource.Id);
                if(costElement.NameText != null)
                    costElement.NameText.text = cardCost.CardResource.Name;
                costElement.AmountText.text = cardCost.Amount.ToString();
            }
        }
    }
}