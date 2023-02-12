using _Anark.Scripts.GeneralUse.MachineState;
using UnityEngine;

namespace _ProjectBeatBox.GameElements.Game
{
    public class PlayerNormalState : MonoBehaviour , IState
    {
        [field: SerializeField] public string StateId { get; set; }
        
        public void Enter()
        {
            Debug.Log("Enter State");
            GameManager.Instance.PlayerReferences.button.interactable = true;
        }

        public void Execute()
        {
            
        }

        public void Exit()
        {
            Debug.Log("Exit State");
            GameManager.Instance.PlayerReferences.button.interactable = false;
        }
    }
}