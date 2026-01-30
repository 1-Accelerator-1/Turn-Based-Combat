using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Unit
{
    public class UnitPopUpGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject _damagePopUpPrefab;
        [SerializeField] private GameObject _healPopUpPrefab;

        private UnitHealth _unitHealth;

        private void Awake()
        {
            _unitHealth = GetComponent<UnitHealth>();
        }

        private void OnEnable()
        {
            _unitHealth.OnDamageTaken.AddListener(CreateDamagePopUp);
            _unitHealth.OnHealTaken.AddListener(CreateHealPopUp);
        }

        private void OnDisable()
        {
            _unitHealth.OnDamageTaken.RemoveListener(CreateDamagePopUp);
            _unitHealth.OnHealTaken.RemoveListener(CreateHealPopUp);
        }

        public void CreateDamagePopUp(int damageAmount)
        {
            GameObject damagePopUpObject = Instantiate(_damagePopUpPrefab, gameObject.transform.position, Quaternion.identity);
            PopUpMessage damagePopUp = damagePopUpObject.GetComponent<PopUpMessage>();

            damagePopUp.SetValue(damageAmount.ToString());
        }

        public void CreateHealPopUp(int healAmount)
        {
            GameObject healPopUpObject = Instantiate(_healPopUpPrefab, gameObject.transform.position, Quaternion.identity);
            PopUpMessage healPopUp = healPopUpObject.GetComponent<PopUpMessage>();

            healPopUp.SetValue(healAmount.ToString());
        }
    }
}
