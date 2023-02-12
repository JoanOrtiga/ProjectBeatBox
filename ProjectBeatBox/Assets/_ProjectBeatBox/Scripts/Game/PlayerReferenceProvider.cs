using System;
using System.Collections;
using System.Collections.Generic;
using _Anark.Scripts.Cards.TurnSystem;
using _ProjectBeatBox.GameElements.Game;
using _ProjectBeatBox.GameElements.Game.Players;
using Unity.Netcode;
using UnityEngine;

public class PlayerReferenceProvider : NetworkBehaviour
{
    public NetworkList<ulong> playerIdToReference;
    //public NetworkList<ulong> PlayerIdToReference => _playerIdToReference;

    [field: SerializeField] public PlayerReference[] PlayerReferences { get; private set; }

    private void Awake()
    {
        playerIdToReference = new NetworkList<ulong>(new List<ulong>(), NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Server);
        
        playerIdToReference.OnListChanged += SetPlayerReference;
    }
    
    public override void OnDestroy()
    {
        playerIdToReference.OnListChanged -= SetPlayerReference;
        base.OnDestroy();
    }

    private void SetPlayerReference(NetworkListEvent<ulong> elementChanged)
    {
        PlayerReferences[elementChanged.Index].SetPlayerId((int)elementChanged.Value);
    }
}
