using System.Collections.Generic;
using UnityEngine;

namespace _ProjectBeatBox_SinglePlayer.Turns
{
    [CreateAssetMenu(menuName = "7ToBeat/Player reference", fileName = "Player reference", order = 0)]
    public class PlayerReference : ScriptableObject
    {
        public bool Assigned { get; private set; }
        private Player _playerComponent;

        public void Init(Player playerComponent)
        {
            _playerComponent = playerComponent;
            Assigned = true;
        }
        

    }
}