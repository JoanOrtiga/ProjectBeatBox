using _Anark.Scripts.Cards.Data.Settings;
using UnityEngine;

namespace _Anark.Scripts.Cards.Data
{
    [CreateAssetMenu(menuName = "Card/Object", fileName = "ObjectCard")]
    public class ObjectCard : Card
    {
        [field: SerializeField] public CardCost[] Cost { get; private set; }
        [field: SerializeField] public CardResourcesStatus[] Resources { get; private set; }
        [field: SerializeField] public CardStatStatus[] Status { get; private set; }
    }
}