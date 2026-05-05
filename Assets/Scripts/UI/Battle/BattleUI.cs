using System.Collections.Generic;
using Assets.Scripts.UI.Battle.Unit;
using Assets.Scripts.Unit;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class BattleUI : MonoBehaviour
{
    [SerializeField] private UIDocument _battleUIDocument;

    [SerializeField] private VisualTreeAsset _playerUnitInfoTemplate;
    [SerializeField] private VisualTreeAsset _turnIconTemplate;

    public void SetPlayerUnitInfoUI(IEnumerable<GameObject> playerUnitGameObjects)
    {
        var playerUnitInfoContainer = _battleUIDocument.rootVisualElement.Q<VisualElement>("PlayerUnitHUDContainer");
        
        foreach (var playerUnitGameObject in playerUnitGameObjects)
        {
            var playerUnitStats = playerUnitGameObject.GetComponent<UnitStats>();
            var playerUnitHealth = playerUnitGameObject.GetComponent<UnitHealth>();

            var playerUnitInfo = _playerUnitInfoTemplate.Instantiate();

            var playerUnitBattleHUD = new PlayerUnitBattleHUD(playerUnitStats, playerUnitHealth, playerUnitInfo);

            playerUnitInfoContainer.Add(playerUnitInfo);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Add Turn Icon to Turn order panel
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            var turnOrderPanel = _battleUIDocument.rootVisualElement.Q<VisualElement>("TurnOrderPanel");
            
            var newTurnIcon = _turnIconTemplate.CloneTree();

            turnOrderPanel.Add(newTurnIcon);
        }

        // Add Player Unit Info tamplate to Player Unit Info container
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            var playerUnitInfoContainer = _battleUIDocument.rootVisualElement.Q<VisualElement>("PlayerUnitInfoContainer");
            
            var newPlayerUnitInfo = _playerUnitInfoTemplate.CloneTree();

            playerUnitInfoContainer.Add(newPlayerUnitInfo);
        }
    }
}
