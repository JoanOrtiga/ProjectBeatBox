using System;
using UnityEngine;

namespace _ProjectBeatBox_SinglePlayer.Turns
{
    public abstract class TurnBehaviour : MonoBehaviour
    {
        public abstract void Init(TurnSettings turnSettings);
    }
}