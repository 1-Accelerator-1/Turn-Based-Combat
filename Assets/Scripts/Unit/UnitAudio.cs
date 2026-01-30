using Assets.Scripts.CustomTypes;
using Assets.Scripts.Unit.Enums;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Scripts.Unit
{
    public class UnitAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private SerializableDictionary<UnitState, AudioResource> serializebleDictionary;

        private Dictionary<UnitState, AudioResource> _audioClipsByState;

        private UnitHealth _unitHealth;
        private UnitCombat _unitCombat;

        private void Awake()
        {
            _unitHealth = GetComponent<UnitHealth>();
            _unitCombat = GetComponent<UnitCombat>();
        }

        private void Start()
        {
            _audioClipsByState = serializebleDictionary.ToDictionary();
        }

        private void OnEnable()
        {
            _unitHealth.OnDamageTaken.AddListener(PlayHurtSound);
            _unitHealth.OnHealTaken.AddListener(PlayHealSound);

            _unitCombat.OnAttack.AddListener(PlayAttackSound);
        }

        private void OnDisable()
        {
            _unitHealth.OnDamageTaken.RemoveListener(PlayHurtSound);
            _unitHealth.OnHealTaken.RemoveListener(PlayHealSound);

            _unitCombat.OnAttack.RemoveListener(PlayAttackSound);
        }

        public void PlayHurtSound(int damageAmount)
        {
            if (_unitHealth.IsDead)
            {
                PlaySoundByState(UnitState.Death);
            }
            else
            {
                PlaySoundByState(UnitState.Hurt);
            }
        }

        public void PlayHealSound(int healAmount)
        {
            PlaySoundByState(UnitState.Heal);
        }

        public void PlayAttackSound()
        {
            PlaySoundByState(UnitState.Attack);
        }

        private void PlaySoundByState(UnitState state)
        {
            // if (_audioClipsByState.ContainsKey(state) && _audioClipsByState[state].Length > 0)
            // {
            //     int randomIndex = Random.Range(0, _audioClipsByState[state].Length);
            //     _audioSource.PlayOneShot(_audioClipsByState[state][randomIndex]);
            // }

            if (_audioClipsByState.ContainsKey(state) && _audioClipsByState[state] is IAudioGenerator)
            {
                _audioSource.generator = _audioClipsByState[state] as IAudioGenerator;
                _audioSource.Play();
            }
        }
    }
}
