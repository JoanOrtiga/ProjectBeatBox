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

            var objectCard = card as ObjectCard;
            Assert.IsNotNull(objectCard, $"Card should be type {nameof(ObjectCard)}");
            
            FillStatsData(objectCard);
            FillCostData(objectCard);
            FillResourcesData(objectCard);
        }

        private void FillStatsData(ObjectCard objectCard)
        {
            foreach (var statElement in statElements)
            {
                var statStatus = objectCard.Status.First(cardStatStatus => cardStatStatus.StatData.Id == statElement.StatData.Id);
                if(statElement.NameText != null)
                    statElement.NameText.text = statStatus.StatData.Name;
                statElement.AmountText.text = statStatus.Amount.ToString();
            }
        }

        private void FillResourcesData(ObjectCard objectCard)
        {
            foreach (var resourceElement in resourceElements)
            {
                var cardResource = objectCard.Resources.First(cardResource =>  cardResource.ResourceData.Id == resourceElement.ResourceData.Id);
                if(resourceElement.NameText != null)
                    resourceElement.NameText.text = cardResource.ResourceData.Name;
                resourceElement.AmountText.text = cardResource.Amount.ToString();
            }
        }

        private void FillCostData(ObjectCard objectCard)
        {
            if (objectCard.Cost == null || objectCard.Cost.Length == 0)
                return;
            
            foreach (var costElement in costElements)
            {
                var cardCost = objectCard.Cost.First(cardCost => cardCost.CardResource.Id == costElement.CostData.CardResource.Id);
                if(costElement.NameText != null)
                    costElement.NameText.text = cardCost.CardResource.Name;
                costElement.AmountText.text = cardCost.Amount.ToString();
            }
        }
    }
}