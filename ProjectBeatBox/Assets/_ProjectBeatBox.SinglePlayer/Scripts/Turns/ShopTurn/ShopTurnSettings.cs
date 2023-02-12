using UnityEngine;

namespace _ProjectBeatBox_SinglePlayer.Turns
{
    [CreateAssetMenu(menuName = "7ToBeat/Turns/ShopTurn", fileName = "ShopTurn", order = 0)]
    public class ShopTurnSettings : TurnSettings
    {
        [field: Header(nameof(ShopTurnBehaviour))]
        [field: SerializeField] public float Time { get; private set; }
    }
}