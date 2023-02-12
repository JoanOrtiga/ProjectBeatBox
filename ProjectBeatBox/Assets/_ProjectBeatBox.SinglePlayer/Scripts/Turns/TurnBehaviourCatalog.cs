using UnityEngine;

namespace _ProjectBeatBox_SinglePlayer.Turns
{
    public class TurnBehaviourCatalog : MonoBehaviour
    {
        [SerializeField] private ShopTurnBehaviour shopTurnBehaviour;

        public void SetTurn<T>(T turnSettings) where T : TurnSettings
        {
            if (turnSettings.GetType() == typeof(ShopTurnSettings))
            {
                shopTurnBehaviour.Init(turnSettings as ShopTurnSettings);
            }
        }
    }
}