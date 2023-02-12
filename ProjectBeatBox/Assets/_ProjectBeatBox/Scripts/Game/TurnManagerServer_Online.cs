using System.Collections.Generic;
using _Anark.Scripts.Game.TurnSystem;
using _ProjectBeatBox.GameElements.Game.Players;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace _ProjectBeatBox.GameElements.Game
{
    [RequireComponent(typeof(TurnManagerClient))]
    public class TurnManagerServer_Online : NetworkBehaviour
    {
        private TurnManagerClient _turnManagerClient;
        
        private bool _turnActive;
        private float _countdown;

        #region SHARED

        private NetworkList<ulong> _playersRegistered;
        private NetworkVariable<bool> _gameStarted = new(false, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);

        private NetworkVariable<int> _turnIndex = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Server);
        public bool IsGameStarted => _gameStarted.Value;       
        
        #endregion

        private TurnSettings _turnSettings;
        private TurnBehaviour _turnBehaviour;
        
        
        private void Awake()
        {
            _turnManagerClient = GetComponent<TurnManagerClient>();
            
            _playersRegistered = new NetworkList<ulong>(new List<ulong>(),
                NetworkVariableReadPermission.Owner, NetworkVariableWritePermission.Server);

            _turnSettings = GameManager.Instance.TurnSettings;
        }
        

        [ServerRpc(RequireOwnership = false)]
        public void RegisterPlayerServerRpc(ServerRpcParams serverRpcParams = default)
        {
            var clientId = serverRpcParams.Receive.SenderClientId;
            
            Debug.Log($"Registered player: {clientId}");
            _playersRegistered.Add(clientId);

            InitializeCardDeck(clientId);

            if(_playersRegistered.Count >= 2)
                StartGame();
        }

        private void InitializeCardDeck(ulong clientId)
        {
            var deck = GameManager.Instance.DeckProvider.CreateCardDeck();
            
            IPlayer player = NetworkManager.ConnectedClients[clientId].PlayerObject
                .GetComponent<IPlayer>();
            player.StringifyDeck(DeckProvider.CardDeckToString(deck));
        }

        private void StartGame()
        {
            if (!IsServer)
                return;
            
            Debug.Log("StartingGame");
            _gameStarted.Value = true;
            
            SetupGame();
        }

        private void SetupGame()
        {
            var randomFirstPlayer = Random.Range(0, 1);
            GameManager.Instance.PlayerReferenceProvider.playerIdToReference.Add(_playersRegistered[randomFirstPlayer]);
            GameManager.Instance.PlayerReferenceProvider.playerIdToReference.Add(_playersRegistered[randomFirstPlayer == 0 ? 1 : 0]);
            
            NextTurn();
        }

        private void NextTurn()
        {
            _turnBehaviour = _turnSettings.GetTurnBehaviourByIndex(_turnIndex.Value);

            _turnActive = true;
            _turnBehaviour.StartTurn();
        }

        private void EndTurn()
        {
            _turnIndex.Value++;

            if (_turnIndex.Value >= _turnSettings.GetNumberOfTurns())
            {
                _turnIndex.Value = 0;
            }
            
            NextTurn();
        }

        
        private void Update()
        {
            if (!IsServer || !IsGameStarted || !_turnActive)
                return;

            if (!_turnActive)
                return;

            _turnBehaviour.Update();
            if (_turnBehaviour.IsTurnFinished())
            {
                _turnBehaviour.EndTurn();
                EndTurn();
            }
        }

    /*    private void ChangeTurn()
        {
            if (!IsServer)
                return;
            
            var currentTurnClientRpcParams = new ClientRpcParams
            {
                Send = new ClientRpcSendParams
                {
                    TargetClientIds = new ulong[]{_playersRegistered[turn.Value]}
                }
            };
            
            turn.Value = turn.Value == 1 ? (ushort)0 : (ushort)1;
            
            var nextTurnClientRpcParams = new ClientRpcParams
            {
                Send = new ClientRpcSendParams
                {
                    TargetClientIds = new ulong[]{_playersRegistered[turn.Value]}
                }
            };

            _turnManagerClient.EndTurnClientRpc(currentTurnClientRpcParams);
            _turnManagerClient.StartTurnClientRpc(nextTurnClientRpcParams);
            StartTimer();
        }*/
    }
}
