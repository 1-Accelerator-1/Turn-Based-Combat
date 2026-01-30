using Assets.Scripts.Unit;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerCombat : UnitCombat
    {
        [SerializeField] private UnitEquipment _unitEquipment;

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
            if (_unitEquipment is not null)
                return _unitEquipment.GetWeapon().Damage;

            return 0;
        }
    }
}