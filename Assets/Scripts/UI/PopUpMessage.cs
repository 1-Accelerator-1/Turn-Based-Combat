using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class PopUpMessage : MonoBehaviour
    {
        [SerializeField] private float _moveYSpeed;
        [SerializeField] private float _lifeTime;

        private TMP_Text _damageText;

        private void Awake()
        {
            _damageText = GetComponentInChildren<TMP_Text>();
        }

        private void Update()
        {
            transform.position += new Vector3(0, _moveYSpeed) * Time.deltaTime;
            _lifeTime -= Time.deltaTime;

            if (_lifeTime <= 0)
            {
                Destroy(gameObject);
            }
        }

        public void SetValue(string text)
        {
            _damageText.SetText(text);
        }
    }
}
