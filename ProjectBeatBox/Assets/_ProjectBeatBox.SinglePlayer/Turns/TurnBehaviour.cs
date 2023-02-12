using System;
using UnityEngine;

namespace _ProjectBeatBox_SinglePlayer.Turns
{
    public abstract class TurnBehaviour<T> : MonoBehaviour , ITurnBehaviourToCatalog where T : TurnSettings
    {
        protected T TurnSettings { get; private set; }

        public virtual void Init(T turnSettings)
        {
            TurnSettings = turnSettings;
        }

        public object GetTurn => TurnSettings;
        public Type GetTurnType => typeof(T);
    }
}