using _ProjectBeatBox.GameElements.Game.Players;
using Unity.Netcode;
using UnityEngine;

namespace _ProjectBeatBox.GameElements.Game
{
    [RequireComponent(typeof(TurnManagerServer_Online))]
    public class TurnManagerClient : NetworkBehaviour
    {
        private TurnManagerServer_Online _turnManagerServerOnline;
        
        private IPlayer _player;
        
        private void Awake()
        {
            _turnManagerServerOnline = GetComponent<TurnManagerServer_Online>();
        }

        public void RegisterPlayer(IPlayer player)
        {
            _player = player;
            _turnManagerServerOnline.RegisterPlayerServerRpc();
        }
    }
}