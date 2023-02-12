using System;
using System.Collections;
using System.Collections.Generic;
using _Anark.Scripts.Cards;
using _Anark.Scripts.Cards.Data;
using _Anark.Scripts.GeneralUse.MachineState;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace _ProjectBeatBox.GameElements.Game.Players
{
    public class OnlinePlayer : NetworkBehaviour , IPlayer
    {
        private PlayerReferences _playerReferences;
        private CardDeck _deck;

        private NetworkList<FixedString32Bytes> _stringifyDeck;

        private IMachineState _machineState;
        
        
        private void Awake()
        {
            _stringifyDeck = new NetworkList<FixedString32Bytes>(new List<FixedString32Bytes>(),
                NetworkVariableReadPermission.Owner, NetworkVariableWritePermission.Server);
            _deck = new CardDeck();

            _machineState = GetComponent<IMachineState>();
        }
        
        public override void OnNetworkSpawn()
        {
            if (!IsOwner)
            {
                return;
            }
        
            _playerReferences = GameManager.Instance.PlayerReferences;
            StartCoroutine(WaitForTurnManager());
        }

        IEnumerator WaitForTurnManager()
        {
            while (!GameManager.Instance.TurnManagerClient.IsSpawned)
            {
                yield return null;
            }
            GameManager.Instance.TurnManagerClient.RegisterPlayer(this);
        }

        private void SetupDeck()
        {
            var newCards = new List<Card>();
            foreach (var cardId in _stringifyDeck)
            {
                var newCard = GameManager.Instance.CardProvider.GetCard(cardId.ToString());
                newCards.Add(newCard);
            }
            _deck.SetNewDeck(newCards);  
        }
        
        private void NewTurn()
        {
            SetupDeck();
            foreach (var card in _deck.GetCardsFromDeck)
            {
                Debug.Log(card.Id);
            }
        }

        public void StringifyDeck(List<FixedString32Bytes> cards)
        {
            foreach (var card in cards)
            {
                _stringifyDeck.Add(card);    
            }
        }

        public void ChangePlayerState(string state)
        {
            ChangePlayerStateClientRpc(state, new ClientRpcParams()
            {
                Send =
                {
                    TargetClientIds = new []{OwnerClientId}
                }
            });
        }

        [ClientRpc]
        private void ChangePlayerStateClientRpc(string state, ClientRpcParams clientRpcParams = default)
        {
            _machineState.ChangeState(state);
        }
    }
}