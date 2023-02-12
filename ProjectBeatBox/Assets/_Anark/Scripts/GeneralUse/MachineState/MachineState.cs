using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Anark.Scripts.GeneralUse.MachineState
{
    public sealed class MachineState : MonoBehaviour , IMachineState
    {
        private Dictionary<string, IState> _states = new Dictionary<string, IState>();
        
        public IState CurrentState { get; private set; }
        
        private void Awake()
        {
            var states = GetComponents<IState>();
            foreach (var state in states)
            {
                _states.Add(state.StateId, state);
            }
            _states.Add(string.Empty, null);
            
            if(_states.ContainsKey(IState.InitialStateId))
                ChangeState(IState.InitialStateId);
        }
        
        public void ChangeState(string stateId)
        {
            ChangeState(_states[stateId]);
        }

        public void ChangeState(IState newState)
        {
            if (CurrentState != null)
                CurrentState.Exit();
 
            CurrentState = newState;
            CurrentState?.Enter();
        }

        public void Update()
        {
            if (CurrentState != null) 
                CurrentState.Execute();
        }
    }
}