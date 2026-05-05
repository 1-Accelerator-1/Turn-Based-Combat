using Assets.Scripts.TurnBasedBattle.States;
using Assets.Scripts.UI.Battle;
using UnityEngine;

namespace Assets.Scripts.TurnBasedBattle
{
    public class TurnBasedBattleSystem : MonoBehaviour
    {
        [HideInInspector] public StateMachine BattleStateMachine { get; private set; }

        [HideInInspector] public BattleStartState StartState { get; private set; }
        [HideInInspector] public BattlePlayerTurnState PlayerTurnState { get; private set; }
        [HideInInspector] public BattleEnemyTurnState EnemyTurnState { get; private set; }
        [HideInInspector] public BattleEndState EndState { get; private set; }

        public BattleManager BattleManager;
        public BattleUI BattleUI;

        void Start()
        {
            BattleStateMachine = new StateMachine();

            StartState = new BattleStartState(this);
            PlayerTurnState = new BattlePlayerTurnState(this);
            EnemyTurnState = new BattleEnemyTurnState(this);
            EndState = new BattleEndState(this);

            BattleStateMachine.InitializeState(StartState);
        }

        void Update()
        {
            if (BattleStateMachine.CurrentState is not null)
            {
                BattleStateMachine.CurrentState.Update();
            }
        }
    }
}