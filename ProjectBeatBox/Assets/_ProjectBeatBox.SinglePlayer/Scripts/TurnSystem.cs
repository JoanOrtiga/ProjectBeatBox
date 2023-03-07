using System;
using System.Collections.Generic;
using _ProjectBeatBox_SinglePlayer;
using _ProjectBeatBox_SinglePlayer.ReferenceSystem;
using _ProjectBeatBox_SinglePlayer.Turns;
using UnityEngine;
using UnityEngine.Serialization;

namespace _ProjectBeatBox.SinglePlayer
{
    public class TurnSystem : MonoBehaviour
    {
        [SerializeField] private TurnSystemReference turnSystemReference; 
        [SerializeField] private TurnBehaviourCatalog turnBehaviourCatalog;
        [SerializeField] private GameMode gameMode;

        private int _currentTurnIndex = 0;
        

        private void Awake()
        {
            turnSystemReference.SetReference(this);

            gameMode.Init();
        }

        public void AddPlayer(Player player)
        {
            AssignPlayerReference(player);

            if (gameMode.AllPlayersAssigned)
            {
                StartGame();
            }
        }

        private void AssignPlayerReference(Player player)
        {
            gameMode.GetRandomPlayerReference().Init(player);
        }
        
        private void StartGame()
        {
            turnBehaviourCatalog.SetTurn(gameMode.Turns[_currentTurnIndex]);
        }
    }
}
