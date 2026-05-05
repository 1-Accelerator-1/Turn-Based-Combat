using Assets.Scripts.Unit;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyCombat : UnitCombat
    {
        public void Attack(GameObject targetUnit)
        {
            int damageAmount = CalculateDamage();

            AttackTarget(targetUnit, damageAmount);
        }

        public void Heal()
        {
            _unitHealth.TakeHeal(_unitStats.Heal);
        }

        private int CalculateDamage()
        {
            return _unitStats.Strength;
        }
    }
}