using UnityEngine;

namespace _ProjectBeatBox.GameElements.Cards.Scripts
{
    public abstract class Card : ScriptableObject
    {
        [field: SerializeField] public string Id { get; private set; }
        [field: SerializeField] public string Name { get; private set; } 
        [field: SerializeField] public Sprite FrontImage { get; private set; }
        [field: SerializeField] public Sprite BackImage { get; private set; }
    }
}
