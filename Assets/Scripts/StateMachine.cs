namespace Assets.Scripts
{
    public class StateMachine
    {
        public IState CurrentState { get; private set; }

        public void InitializeState(IState startingState)
        {
            CurrentState = startingState;
            startingState.Enter();
        }

        public void ChangeState(IState nextState)
        {
            CurrentState.Exit();
            CurrentState = nextState;
            nextState.Enter();
        }
    }
}