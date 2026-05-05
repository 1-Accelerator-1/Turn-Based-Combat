using Assets.Scripts.Unit;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.UI.Battle.Unit
{
    public class PlayerUnitBattleHUD
    {
        private Label _unitName;

        private SliderInt _hpSlider;
        private Label _hpSliderText;
        private VisualElement _hpFillArea;
        private Gradient _hpBarGradient;

        private SliderInt _mpSlider;
        private Label _mpSliderText;

        private UnitHealth _playerUnitHealth;

        public PlayerUnitBattleHUD(
            UnitStats playerUnitStats,
            UnitHealth playerUnitHealth,
            TemplateContainer playerUnitHUDContainer)
        {
            _playerUnitHealth = playerUnitHealth;

            _unitName = playerUnitHUDContainer.Q<Label>("PlayerUnitName");

            _hpSlider = playerUnitHUDContainer.Q<SliderInt>("HP_Slider");
            _mpSlider = playerUnitHUDContainer.Q<SliderInt>("MP_Slider");

            _hpSliderText = _hpSlider.Q<Label>();
            _mpSliderText = _mpSlider.Q<Label>();

            _hpFillArea = _hpSlider.Q<VisualElement>("unity-fill");

            _unitName.text = playerUnitStats.Name;

            _hpSlider.highValue = _playerUnitHealth.MaxHealth;
            _hpSlider.value = _playerUnitHealth.CurrentHealth;

            _hpSliderText.text = $"HP {_playerUnitHealth.CurrentHealth}/{_playerUnitHealth.MaxHealth}";

            _hpBarGradient = GetHPGradient();

            _playerUnitHealth.OnDamageTaken.AddListener(SetCurrentHP);
            _playerUnitHealth.OnHealTaken.AddListener(SetCurrentHP);
        }

        public void SetCurrentHP(int damageAmount)
        {
            _hpSlider.value = _playerUnitHealth.CurrentHealth;
            _hpSliderText.text = $"HP {_playerUnitHealth.CurrentHealth}/{_playerUnitHealth.MaxHealth}";
            _hpFillArea.style.backgroundColor = _hpBarGradient.Evaluate(Mathf.Clamp01(_hpSlider.value));
        }

        private Gradient GetHPGradient()
        {
            var gradient = new Gradient();

            // Blend color from red at 0% to blue at 100%
            var colors = new GradientColorKey[3];
            colors[0] = new GradientColorKey(Color.red, 0.0f);
            colors[1] = new GradientColorKey(Color.yellow, 0.5f);
            colors[2] = new GradientColorKey(Color.green, 1.0f);

            // Blend alpha from opaque at 0% to transparent at 100%
            var alphas = new GradientAlphaKey[2];
            alphas[0] = new GradientAlphaKey(255.0f, 0.0f);
            alphas[1] = new GradientAlphaKey(255.0f, 1.0f);

            gradient.SetKeys(colors, alphas);

            return gradient;
        }
    }
}