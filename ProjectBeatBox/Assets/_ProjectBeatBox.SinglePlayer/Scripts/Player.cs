using System;
using System.Collections;
using System.Collections.Generic;
using _ProjectBeatBox_SinglePlayer;
using _ProjectBeatBox_SinglePlayer.ReferenceSystem;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private TurnSystemReference turnSystem;

    private void Awake()
    {
        turnSystem.Get.AddPlayer(this);
    }
}
