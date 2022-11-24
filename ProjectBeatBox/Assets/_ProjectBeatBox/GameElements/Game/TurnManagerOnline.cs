using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _ProjectBeatBox.GameElements.Game
{
    //Server ONLY
    public class TurnManagerOnline : NetworkBehaviour
    {
        public static TurnManagerOnline Instance;

        private IPlayer _player;
        
        //SERVER ONLY
        private NetworkList<ulong> _playersRegistered;
        
        private NetworkVariable<bool> _gameStarted = new(false, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);
        public bool IsGameStarted => _gameStarted.Value;

        private NetworkVariable<ushort> _turn = new(0, NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Server);
        public bool IsMyTurn => _turn.Value == OwnerClientId;

        private bool _turnActive;
        private float _countdown;
        private const float TimeBetweenTurns = 5;


        private void Awake()
        {
            Instance = this;
            
            _playersRegistered = new NetworkList<ulong>(new List<ulong>(),
                NetworkVariableReadPermission.Owner, NetworkVariableWritePermission.Server);
        }
        
        public void RegisterPlayer(IPlayer player)
        {
            _player = player;
            Debug.Log($"Register player");
            RegisterPlayerServerRpc();
        }
        
        [ServerRpc(RequireOwnership = false)]
        private void RegisterPlayerServerRpc(ServerRpcParams serverRpcParams = default)
        {
            Debug.Log($"Registered player: {serverRpcParams.Receive.SenderClientId}");
            _playersRegistered.Add(serverRpcParams.Receive.SenderClientId);
            
            if(_playersRegistered.Count >= 2)
                StartGame(); // or StartGameServerRpc
        }

        private void StartGame()
        {
            if (!IsServer)
                return;
            
            Debug.Log("StartingGame");
            _gameStarted.Value = true;

            _turn.Value = (ushort)Random.Range(0, 1);
            ChangeTurn();
        }

        
        private void Update()
        {
            if (!IsServer || !IsGameStarted || !_turnActive)
                return;

            _countdown -= Time.deltaTime;
            if (_countdown <= 0)
            {
                _turnActive = false;
                ChangeTurn();
            }
        }

        private void ChangeTurn()
        {
            if (!IsServer)
                return;
            
            var currentTurnClientRpcParams = new ClientRpcParams
            {
                Send = new ClientRpcSendParams
                {
                    TargetClientIds = new ulong[]{_playersRegistered[_turn.Value]}
                }
            };
            
            _turn.Value = _turn.Value == 1 ? (ushort)0 : (ushort)1;
            
            var nextTurnClientRpcParams = new ClientRpcParams
            {
                Send = new ClientRpcSendParams
                {
                    TargetClientIds = new ulong[]{_playersRegistered[_turn.Value]}
                }
            };

            EndTurnClientRpc(currentTurnClientRpcParams);
            StartTurnClientRpc(nextTurnClientRpcParams);
            StartTimer();
        }

        private void StartTimer()
        {
            _countdown = TimeBetweenTurns;
            _turnActive = true;
        }

        [ClientRpc]
        private void StartTurnClientRpc(ClientRpcParams clientRpcParams)
        {
            Debug.Log("Start: " + OwnerClientId);
            _player.StartTurn();
        }
        
        [ClientRpc]
        private void EndTurnClientRpc(ClientRpcParams clientRpcParams)
        {
            Debug.Log("End: " + OwnerClientId);
            _player.EndTurn();
        }
    }
}
