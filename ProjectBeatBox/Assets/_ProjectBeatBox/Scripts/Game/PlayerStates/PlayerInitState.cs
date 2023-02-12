using _Anark.Scripts.GeneralUse.MachineState;
using UnityEngine;

namespace _ProjectBeatBox.GameElements.Game
{
    public class PlayerInitState : MonoBehaviour, IState
    {
        public string StateId { get; set; } = IState.InitialStateId;
        
        public void Enter()
        {
            GameManager.Instance.PlayerReferences.button.interactable = false;
        }

        public void Execute()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}