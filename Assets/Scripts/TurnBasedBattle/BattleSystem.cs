using Assets.Scripts;
using Assets.Scripts.Enemy;
using Assets.Scripts.Player;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    private BattleState state;

    private PlayerCombat _playerUnitCombat;
    private EnemyCombat _enemyUnitCombat;

    private GameObject _playerGameObject;
    private GameObject _enemyGameObject;

    [SerializeField] private Button _attackButton;
    [SerializeField] private Button _healButton;

    [SerializeField] private TMP_Text _battleDialogText;

    public void StartBattle(GameObject playerGameObject, GameObject enemyGameObject)
    {
        state = BattleState.Start;

        _playerGameObject = playerGameObject;
        _enemyGameObject = enemyGameObject;

        _playerUnitCombat = _playerGameObject.GetComponent<PlayerCombat>();
        _enemyUnitCombat = _enemyGameObject.GetComponent<EnemyCombat>();

        PlayerTurn();
    }

    private void PlayerTurn()
    {
        state = BattleState.PlayerTurn;
        _battleDialogText.text = "Choose an action...";

        if (!_attackButton.gameObject.activeSelf && !_healButton.gameObject.activeSelf)
        {
            _attackButton.gameObject.SetActive(true);
            _healButton.gameObject.SetActive(true);
        }
        else if (!_attackButton.interactable && !_healButton.interactable)
        {
            _attackButton.interactable = true;
            _healButton.interactable = true;
        }
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PlayerTurn)
        {
            return;
        }

        _attackButton.interactable = false;
        _healButton.interactable = false;

        StartCoroutine(PlayerAttack());
    }

    public void OnHealButton()
    {
        if (state != BattleState.PlayerTurn)
        {
            return;
        }

        _attackButton.interactable = false;
        _healButton.interactable = false;

        StartCoroutine(PlayerHeal());
    }

    private IEnumerator PlayerAttack()
    {
        _playerUnitCombat.OnAttack.Invoke();

        yield return new WaitForSeconds(0.5f);

        _playerUnitCombat.Attack(_enemyGameObject);

        _battleDialogText.text = "The Attack is successful!";

        yield return new WaitForSeconds(1f);

        if (!_enemyGameObject)
        {
            // End battle
            state = BattleState.Win;
            EndBattle();
        }
        else
        {
            // Enemy turn
            StartCoroutine(EnemyTurn());
        }
    }

    private IEnumerator PlayerHeal()
    {
        _playerUnitCombat.Heal();

        _battleDialogText.text = $"You heal yourself!";

        yield return new WaitForSeconds(1f);

        StartCoroutine(EnemyTurn());
    }

    private IEnumerator EnemyTurn() // Enemy Attack by default
    {
        state = BattleState.EnemyTurn;
        _battleDialogText.text = $"The Enemy attacks you!";

        yield return new WaitForSeconds(1f);

        _enemyUnitCombat.Attack(_playerGameObject);

        yield return new WaitForSeconds(1f);

        if (_playerGameObject is null)
        {
            state = BattleState.Lose;
            EndBattle();
        }
        else
        {
            PlayerTurn();
        }
    }

    private void EndBattle()
    {
        if (state == BattleState.Win)
        {
            _battleDialogText.text = "You won the battle!";
        }
        else if (state == BattleState.Lose)
        {
            _battleDialogText.text = "You are defeated!";
        }

        _attackButton.interactable = false;
        _healButton.interactable = false;
    }
}
