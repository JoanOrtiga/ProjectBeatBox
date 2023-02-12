using System.Collections.Generic;
using System.Linq;
using _Anark.Scripts.Cards.TurnSystem;
using _ProjectBeatBox.GameElements.Game;
using _ProjectBeatBox.GameElements.Game.Players;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Assertions;

namespace _Anark.Scripts.Game.TurnSystem
{
    public abstract class TurnBehaviour : ScriptableObject
    {
        [field: SerializeField] protected string Id { get; private set; }
        [field: SerializeField] protected PlayerReference[] AffectedPlayers { get; private set; }
        
        public abstract void SetData(TurnAssetReferences turnAssetReferences);
        public abstract bool IsTurnFinished();
        public abstract void Update();

        public virtual void StartTurn()
        {
            foreach (var connectedClient in NetworkManager.Singleton.ConnectedClients)
            {
                if(AffectedPlayers.Any(x=> x.PlayerId == (int)connectedClient.Key))
                {
                    (connectedClient.Value.PlayerObject.GetComponent<IPlayer>()).ChangePlayerState(Id);                    
                }
            }
        }

        public virtual void EndTurn()
        {
            foreach (var connectedClient in NetworkManager.Singleton.ConnectedClients)
            {
                if(AffectedPlayers.Any(x=> x.PlayerId == (int)connectedClient.Key))
                {
                    (connectedClient.Value.PlayerObject.GetComponent<IPlayer>()).ChangePlayerState(string.Empty);                    
                }
            }
        }
    }
}