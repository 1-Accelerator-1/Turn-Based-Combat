using Assets.Scripts.Unit;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Unit
{
    public class UnitBattleHUD : MonoBehaviour
    {
        [SerializeField] private TMP_Text unitName;
        [SerializeField] private TMP_Text unitLevel;
        [SerializeField] private TMP_Text unitHP;

        [SerializeField] private Slider hpSlider;
        [SerializeField] private Gradient hpBarGradient;
        [SerializeField] private Image fill;

        private UnitHealth _unitHealth;

        public void SetHUD(UnitStats unitStats, UnitHealth unitHealth)
        {
            _unitHealth = unitHealth;

            unitName.text = unitStats.Name;
            unitLevel.text = $"Lvl {unitStats.Level}";
            unitHP.text = $"HP {_unitHealth.CurrentHealth}/{_unitHealth.MaxHealth}";

            hpSlider.maxValue = _unitHealth.MaxHealth;
            hpSlider.value = _unitHealth.CurrentHealth;

            fill.color = hpBarGradient.Evaluate(1f);

            // Add Observers
            _unitHealth.OnDamageTaken.AddListener(SetCurrentHP);
            _unitHealth.OnHealTaken.AddListener(SetCurrentHP);
        }

        public void SetCurrentHP(int damageAmount)
        {
            hpSlider.value = _unitHealth.CurrentHealth;
            unitHP.text = $"HP {_unitHealth.CurrentHealth}/{_unitHealth.MaxHealth}";
            fill.color = hpBarGradient.Evaluate(hpSlider.normalizedValue);
        }
    }
}
