using System.Collections.Generic;
using System.Linq;
using _Anark.Scripts.Cards.Data;
using UnityEngine;
using UnityEngine.Assertions;

namespace _ProjectBeatBox.GameElements.Game
{
    public class CardProvider : MonoBehaviour
    {
        [field: SerializeField] public CardsInstaller CardsInstaller { get; private set; }

        public Card GetCard(string id)
        {
            var card = CardsInstaller.AllCards.FirstOrDefault((card) => card.Id == id);
            Assert.IsNotNull(card, $"Card with {id} doesn't exist.");
            return card;
        }
    }
}
