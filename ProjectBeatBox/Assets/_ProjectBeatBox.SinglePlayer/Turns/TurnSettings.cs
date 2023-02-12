using System;
using System.Collections.Generic;
using UnityEngine;

namespace _ProjectBeatBox_SinglePlayer.Turns
{
    public abstract class TurnSettings : ScriptableObject
    {
#if UNITY_EDITOR
        [Header("Information")]
        [SerializeField, TextArea, Multiline]
        private string TurnDescription;
#endif
        
        public List<PlayerReference> AffectedPlayers;
    }
}