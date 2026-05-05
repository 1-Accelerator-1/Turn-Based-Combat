using Assets.Scripts.UI.Unit;
using Assets.Scripts.Unit;
using UnityEngine;

namespace Assets.Scripts
{
    public class BattleInitializer : MonoBehaviour
    {
        public GameObject playerPrefab;
        public GameObject enemyPrefab;

        public Transform playerBattleStation;
        public Transform enemyBattleStation;

        public UnitBattleHUD playerBattleHUD;

        public BattleSystem battleSystem;

        private void Start()
        {
            SetupBattle();
        }

        private void SetupBattle()
        {
            // Spawn Player and Enemy
            var playerGameObject = Instantiate(playerPrefab, playerBattleStation);
            var enemyGameObject = Instantiate(enemyPrefab, enemyBattleStation);

            var playerUnitStats = playerGameObject.GetComponent<UnitStats>();

            var playerUnitHealth = playerGameObject.GetComponent<UnitHealth>();

            // Set Player and Enemy HUDs
            playerBattleHUD.SetHUD(playerUnitStats, playerUnitHealth);

            battleSystem.StartBattle(playerGameObject, enemyGameObject);
        }
    }
}
