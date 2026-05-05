namespace Assets.Scripts.TurnBasedBattle.States
{
    public abstract class BattleState : IState
    {
        protected StateMachine _battleStateMachine;
        protected TurnBasedBattleSystem _turnBasedBattleSystem;

        public BattleState(TurnBasedBattleSystem turnBasedBattleSystem)
        {
            _turnBasedBattleSystem = turnBasedBattleSystem;
            _battleStateMachine = _turnBasedBattleSystem.BattleStateMachine;
        }

        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }

        public virtual void Update()
        {
        }
    }
}