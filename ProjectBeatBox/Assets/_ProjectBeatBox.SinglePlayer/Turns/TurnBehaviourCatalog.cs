using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace _ProjectBeatBox_SinglePlayer.Turns
{
    public class TurnBehaviourCatalog : MonoBehaviour
    {
        [SerializeField] private ShopTurnBehaviour shopTurnBehaviour;

        public void SetTurn<T>(T turnSettings) where T : TurnSettings
        {
            if (shopTurnBehaviour.GetTurnType == typeof(T))
            {
                shopTurnBehaviour.Init<T>(turnSettings);
            }
        }
    }
}