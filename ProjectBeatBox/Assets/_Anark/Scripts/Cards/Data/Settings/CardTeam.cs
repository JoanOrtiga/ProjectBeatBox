using UnityEngine;

namespace _Anark.Scripts.Cards.Data.Settings
{
    [CreateAssetMenu(menuName = "Card/Settings/Team", fileName = "Team")]
    public class CardTeam : ScriptableObject
    {
        [field: SerializeField] public string Id { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public CardPassive[] Passives { get; private set; }
    }
}