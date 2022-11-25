using UnityEngine;

namespace _Anark.Scripts.Cards.Data.Settings
{
    [CreateAssetMenu(menuName = "Card/Settings/Passive", fileName = "Passive")]
    public class CardActive : ScriptableObject
    {
        [field: SerializeField] public string Id { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
    }
}