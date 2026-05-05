using System.Collections.Generic;
using Assets.Scripts.CustomTypes;
using UnityEngine;

namespace Assets.Scripts.TurnBasedBattle
{
    public class BattleManager : MonoBehaviour
    {
        [Header("Units and Formations")]
        [SerializeField] private SerializableDictionary<Transform, GameObject> _playerUnitFormation;
        [SerializeField] private SerializableDictionary<Transform, GameObject> _enemyUnitFormation;

        private List<GameObject> _playerUnits;
        private List<GameObject> _enemyUnits;

        public List<GameObject> PlayerUnits => _playerUnits;
        public List<GameObject> EnemyUnits => _enemyUnits;

        public void SpawnUnits()
        {
            var playerUnitFormation = _playerUnitFormation.ToDictionary();
            var enemyUnitFormation = _enemyUnitFormation.ToDictionary();

            _playerUnits = new List<GameObject>();
            _enemyUnits = new List<GameObject>();

            foreach (var playerUnitAndPosition in playerUnitFormation)
            {
                var playerUnitGameObject = Instantiate(playerUnitAndPosition.Value, playerUnitAndPosition.Key);
                _playerUnits.Add(playerUnitGameObject);
            }

            foreach (var enemyUnitAndPosition in enemyUnitFormation)
            {
                var enemyUnitGameObject = Instantiate(enemyUnitAndPosition.Value, enemyUnitAndPosition.Key);
                _enemyUnits.Add(enemyUnitGameObject);
            }
        }
    }
}