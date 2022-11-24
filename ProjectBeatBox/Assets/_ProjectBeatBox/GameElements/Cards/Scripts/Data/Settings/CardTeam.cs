using System.Collections.Generic;
using UnityEngine;

namespace _ProjectBeatBox.GameElements.Cards.Scripts.Settings
{
    [CreateAssetMenu(menuName = "Card/Settings/Team", fileName = "Team")]
    public class CardTeam : ScriptableObject
    {
        [field: SerializeField] public string Id { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public CardPassive[] CardPassives { get; private set; }
    }
}