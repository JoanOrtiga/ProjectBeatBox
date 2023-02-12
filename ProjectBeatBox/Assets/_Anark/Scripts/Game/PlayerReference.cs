using System;
using _ProjectBeatBox.GameElements.Game.Players;
using UnityEngine;

namespace _Anark.Scripts.Cards.TurnSystem
{
    /// <summary>
    /// Assigns a multiplayer player to the reference. This reference can later be used in many other context for refering to this player.
    /// </summary>
    [CreateAssetMenu(menuName = "_Anark/Player", fileName = "PlayerReference", order = 0)]
    public class PlayerReference : ScriptableObject
    {
        public int PlayerId { get; private set; } = -1;

        public void SetPlayerId(int playerId)
        {
            PlayerId = playerId;
        }

        public bool HasPlayerAssigned => PlayerId != -1;

        private void OnEnable()
        {
            PlayerId = -1;
        }
    }
}