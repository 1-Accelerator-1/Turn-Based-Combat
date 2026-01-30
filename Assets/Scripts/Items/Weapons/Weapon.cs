using Assets.Scripts.Items.Weapons.Enums;
using UnityEngine;

namespace Assets.Scripts.Items.Weapons
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Equipments/Weapons")]
    public class Weapon : Equipment
    {
        public WeaponType Type;

        public int Damage;

        //public int SlashDamage;
        //public int ThrustDamage;
        //public int PierceDamage;
        //public int StrikeDamage;

        //public int Durability;

        //public float AttackSpeedMultiplier;
        //public float MoveSpeedMultiplier;
    }
}
