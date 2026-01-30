using Assets.Scripts.CustomTypes;
using Assets.Scripts.Items;
using Assets.Scripts.Items.Weapons;
using Assets.Scripts.Unit.Enums;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Unit
{
    public class UnitEquipment : MonoBehaviour
    {
        [SerializeField] private SerializableDictionary<EquipmentSlot, Equipment> _serializableEquipments;

        private Dictionary<EquipmentSlot, Equipment> _equipments;

        public Dictionary<EquipmentSlot, Equipment> Equipments => _equipments;

        private void Start()
        {
            _equipments = _serializableEquipments.ToDictionary();
        }

        public Weapon GetWeapon()
        {
            return _equipments[EquipmentSlot.RightHand] as Weapon;
        }
    }
}
