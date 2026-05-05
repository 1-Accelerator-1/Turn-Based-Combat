using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Unit
{
    public abstract class UnitCombat : MonoBehaviour
    {
        [SerializeField] protected UnitStats _unitStats;
        [SerializeField] protected UnitHealth _unitHealth;

        [HideInInspector] public UnityEvent OnAttack = new UnityEvent();

        protected void AttackTarget(GameObject targetUnit, int damageAmount)
        {
            var targetUnitHealth = targetUnit.GetComponent<UnitHealth>();

            targetUnitHealth.TakeDamage(damageAmount);
        }

        // protected void Heal()
        // {
        //     _unitHealth.TakeHeal(_unitStats.Heal);
        // }

        // private int GetDamage()
        // {
        //     if (_unitEquipment is null)
        //         return _unitStats.Strength;

        //     return _unitEquipment.GetWeapon().Damage;
        // }
    }
}
