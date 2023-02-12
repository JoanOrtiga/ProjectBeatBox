namespace _Anark.Scripts.GeneralUse.MachineState
{
    public interface IMachineState
    {
        public IState CurrentState { get; }
        public void ChangeState(string stateId);
        public void ChangeState(IState newState);
        public void Update();
    }
}