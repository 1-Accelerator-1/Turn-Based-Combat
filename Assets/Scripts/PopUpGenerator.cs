using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts
{
    public class PopUpGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject _damagePopUpPrefab;
        [SerializeField] private GameObject _healPopUpPrefab;

        public static PopUpGenerator Instance;

        private void Awake()
        {
            Instance = this;
        }

        public void CreateDamagePopUp(Vector3 position, int damageAmount)
        {
            GameObject damagePopUpObject = Instantiate(_damagePopUpPrefab, position, Quaternion.identity);
            PopUpMessage damagePopUp = damagePopUpObject.GetComponent<PopUpMessage>();

            damagePopUp.SetValue(damageAmount.ToString());
        }

        public void CreateHealPopUp(Vector3 position, int healAmount)
        {
            GameObject healPopUpObject = Instantiate(_healPopUpPrefab, position, Quaternion.identity);
            PopUpMessage healPopUp = healPopUpObject.GetComponent<PopUpMessage>();

            healPopUp.SetValue(healAmount.ToString());
        }
    }
}
