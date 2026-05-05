using System;
using Assets.Scripts.UI.Battle;

namespace Assets.Scripts.TurnBasedBattle.States
{
    public class BattleStartState : BattleState
    {
        private BattleManager _battleManager;
        private BattleUI _battleUI;

        public BattleStartState(TurnBasedBattleSystem turnBasedBattleSystem) : base(turnBasedBattleSystem)
        {
            _battleManager = turnBasedBattleSystem.BattleManager;
            _battleUI = turnBasedBattleSystem.BattleUI;
        }

        public override void Enter()
        {
            _battleManager.SpawnUnits();
            _battleUI.SetPlayerUnitInfoUI(_battleManager.PlayerUnits);
        }

        public override void Exit()
        {
            
        }

        public override void Update()
        {
            
        }
    }
}