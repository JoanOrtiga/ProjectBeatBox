using UnityEngine;

namespace _ProjectBeatBox.GameElements.Cards.Scripts.Settings
{
    [CreateAssetMenu(menuName = "Card/Settings/Passive", fileName = "Passive")]
    public class CardPassive : ScriptableObject
    {
        [field: SerializeField] public string Id { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
    }
}