namespace _Anark.Scripts.GeneralUse.MachineState
{
    public interface IState
    {
        const string InitialStateId = "Init"; 
        
        public string StateId { get; set; }
        public void Enter();
        public void Execute();
        public void Exit();
    }
}