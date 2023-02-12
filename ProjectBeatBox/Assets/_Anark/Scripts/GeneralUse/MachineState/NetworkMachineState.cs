using System.Collections.Generic;
using Unity.Collections;
using Unity.Netcode;

namespace _Anark.Scripts.GeneralUse.MachineState
{
    public sealed class NetworkMachineState : NetworkBehaviour , IMachineState
    {
        private Dictionary<string, IState> _states = new Dictionary<string, IState>();

        public NetworkVariable<FixedString32Bytes> currentStateId;

        public IState CurrentState { get; private set; }
        protected void Awake()
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

        public override void OnNetworkSpawn()
        {
            base.OnNetworkSpawn();
            currentStateId = new NetworkVariable<FixedString32Bytes>(string.Empty,
                NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);

            currentStateId.OnValueChanged += (value, newValue) => ChangeState(newValue.ToString());
        }

        public override void OnNetworkDespawn()
        {
            base.OnNetworkDespawn();        
            currentStateId.OnValueChanged -= (value, newValue) => ChangeState(newValue.ToString());
        }

        public void ChangeState(string stateId)
        {
            ChangeState(_states[stateId]);
        }

        public void ChangeState(IState newState)
        {
            if (CurrentState != null)
                CurrentState.Exit();
 
            currentStateId.Value = newState.StateId;
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