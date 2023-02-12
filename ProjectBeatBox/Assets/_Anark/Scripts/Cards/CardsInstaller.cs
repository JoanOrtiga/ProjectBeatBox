using System.Collections;
using System.Collections.Generic;
using _Anark.Scripts.Cards.Data;
using UnityEngine;


[CreateAssetMenu(fileName = "CardInstaller", menuName = "Card/CardInstaller")]
public class CardsInstaller : ScriptableObject
{
    [field: SerializeField] public List<Card> AllCards { get; set; }
}
