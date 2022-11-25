using _Anark.Scripts.Cards.Data.Settings;
using UnityEngine;

namespace _Anark.Scripts.Cards.Data
{
    [CreateAssetMenu(menuName = "Card/Character", fileName = "CharacterCard")]
    public class CharacterCard : Card
    {
        [field: SerializeField] public CardCost[] Cost { get; private set; }
        [field: SerializeField] public CardTeam Team { get; private set; }
        [field: SerializeField] public CardResourcesStatus[] Resources { get; private set; }
        [field: SerializeField] public CardStatStatus[] Status { get; private set; }
        
        [field: Header("Optional")]
        [field: SerializeField] public CardPassive[] OverrideTeamPassives { get; private set; }

        public CardPassive[] GetCardPassives()
        {
            if (OverrideTeamPassives == null)
                return Team.Passives;
            if (OverrideTeamPassives.Length <= 0)
                return Team.Passives;

            return OverrideTeamPassives;
        }
    }
}