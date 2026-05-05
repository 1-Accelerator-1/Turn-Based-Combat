using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Unit
{
    public class UnitHealth : MonoBehaviour
    {
        private int _currentHealth;
        private int _maxHealth;

        [SerializeField] private UnitStats _unitStats;
        [SerializeField] private UnitAudio _unitAudio;

        [HideInInspector] public UnityEvent<int> OnDamageTaken = new UnityEvent<int>();
        [HideInInspector] public UnityEvent<int> OnHealTaken = new UnityEvent<int>();

        public int CurrentHealth => _currentHealth;
        public int MaxHealth => _maxHealth;

        public bool IsDead => _currentHealth <= 0;

        private void Awake()
        {
            _currentHealth = _unitStats.Endurance;
            _maxHealth = _unitStats.Endurance;
        }

        public void TakeDamage(int damageAmount)
        {
            _currentHealth -= damageAmount;

            OnDamageTaken.Invoke(damageAmount);

            if (_currentHealth <= 0)
            {
                Destroy(gameObject, 1f);
            }
        }

        public void TakeHeal(int healAmount)
        {
            _currentHealth += healAmount;

            OnHealTaken.Invoke(healAmount);

            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
        }
    }
}
