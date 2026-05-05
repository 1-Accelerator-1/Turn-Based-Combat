using Assets.Scripts.Unit;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Unit
{
    public class UnitMinimalBattleHUD : MonoBehaviour
    {
        [SerializeField] private Slider _hpSlider;
        [SerializeField] private Gradient _hpBarGradient;
        [SerializeField] private Image _hpFillArea;

        private UnitHealth _unitHealth;

        private void Awake()
        {
            _unitHealth = GetComponentInParent<UnitHealth>();
        }

        private void OnEnable()
        {
            _hpSlider.maxValue = _unitHealth.MaxHealth;
            _hpSlider.value = _unitHealth.CurrentHealth;

            _hpFillArea.color = _hpBarGradient.Evaluate(1f);

            // Add Observers
            _unitHealth.OnDamageTaken.AddListener(SetCurrentHP);
            _unitHealth.OnHealTaken.AddListener(SetCurrentHP);
        }

        private void OnDisable()
        {
            // Remove Observers
            _unitHealth.OnDamageTaken.RemoveListener(SetCurrentHP);
            _unitHealth.OnHealTaken.RemoveListener(SetCurrentHP);
        }

        public void SetCurrentHP(int damageAmount)
        {
            _hpSlider.value = _unitHealth.CurrentHealth;
            _hpFillArea.color = _hpBarGradient.Evaluate(_hpSlider.normalizedValue);
        }
    }
}
