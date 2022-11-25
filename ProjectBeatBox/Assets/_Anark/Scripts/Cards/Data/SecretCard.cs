using _Anark.Scripts.Cards.Data.Settings;
using UnityEngine;

namespace _Anark.Scripts.Cards.Data
{
    [CreateAssetMenu(menuName = "Card/Secret", fileName = "ObjectCard")]
    public class SecretCard : Card
    {
        [field: SerializeField] public CardCost[] Cost { get; private set; }
        [field: SerializeField] public CardResourcesStatus[] Resources { get; private set; }
        [field: SerializeField] public CardStatStatus[] Status { get; private set; }
        [field: SerializeField] public CardActive[] Actives { get; private set; }
    }
}