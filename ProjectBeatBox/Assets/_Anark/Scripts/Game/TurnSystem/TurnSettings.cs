using _Anark.Scripts.Cards.TurnSystem;
using UnityEngine;

namespace _Anark.Scripts.Game.TurnSystem
{
    [CreateAssetMenu(menuName = "_Anark/TurnSettings/TurnSettings", fileName = "TurnSettings", order = 0)]
    public class TurnSettings : ScriptableObject
    {
        [SerializeField] private PlayerReference[] playerReferenceAssets;
        [SerializeField] private TurnBehaviour[] turns;

        public TurnBehaviour GetTurnBehaviourByIndex(int turnIndex)
        {
            return turns[turnIndex];
        }

        public int GetNumberOfTurns()
        {
            return turns.Length;
        }
    }
}