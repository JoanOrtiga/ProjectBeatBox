using System.Collections;
using _ProjectBeatBox.GameElements.Game;
using Unity.Netcode;
using UnityEngine;

public class OnlinePlayer : NetworkBehaviour , IPlayer
{
    private PlayerReferences _playerReferences;
    
    public override void OnNetworkSpawn()
    {
        if (!IsOwner)
        {
            return;
        }
        
        _playerReferences = PlayerReferences.Instance;
        StartCoroutine(WaitForTurnManager());
    }

    IEnumerator WaitForTurnManager()
    {
        while (!TurnManagerOnline.Instance.IsSpawned)
        {
            yield return null;
        }
        TurnManagerOnline.Instance.RegisterPlayer(this);
    }

    public void StartTurn()
    {
        _playerReferences.button.interactable = true;
    }

    public void EndTurn()
    {
        _playerReferences.button.interactable = false;
    }
}