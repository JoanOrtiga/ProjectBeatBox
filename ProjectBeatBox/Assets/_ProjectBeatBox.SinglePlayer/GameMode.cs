using System.Collections.Generic;
using _ProjectBeatBox_SinglePlayer.Turns;
using UnityEngine;

namespace _ProjectBeatBox_SinglePlayer
{
    [CreateAssetMenu(menuName = "7ToBeat/GameMode", fileName = "GameMode", order = 50)]
    public class GameMode : ScriptableObject
    {
        [field: Header("Rules")]
        [field: SerializeField] public int RequiredPlayers { get; private set; }
        [field: SerializeField] public List<PlayerReference> PlayersParticipating { get; private set; }

        [field: Header("Turns")]
        [field: SerializeField] public List<TurnSettings> Turns { get; private set; }

        public bool AllPlayersAssigned => _currentPlayers >= RequiredPlayers;
        private int _currentPlayers = 0;
        
        public PlayerReference GetRandomPlayerReference()
        {
            var randomPlayerReference = GetRandomPlayerReference(PlayersParticipating);
            _currentPlayers++;
            return randomPlayerReference;
        }

        private static PlayerReference GetRandomPlayerReference(List<PlayerReference> playerReferences)
        { 
            var nonAssignedPlayers = playerReferences.FindAll(x => !x.Assigned);
            return nonAssignedPlayers[Random.Range(0, nonAssignedPlayers.Count)];
        }   
    }
}