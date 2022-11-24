using System.Collections.Generic;
using _ProjectBeatBox.GameElements.Cards.Scripts.Settings;
using UnityEngine;

namespace _ProjectBeatBox.GameElements.Cards.Scripts
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
                return Team.CardPassives;
            if (OverrideTeamPassives.Length <= 0)
                return Team.CardPassives;

            return OverrideTeamPassives;
        }
    }
}