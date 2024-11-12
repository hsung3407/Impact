using System.Collections;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100f;
        private float _health;
        private bool _isAlive = true;

        [SerializeField] private float maxStamina = 100f;
        private float _stamina;

        [SerializeField] private float defaultStaminaRecovery = 5f;
        [SerializeField] private float recoveryTime = 1;
        private float _recoveryTimer;

        private void Awake()
        {
            _health = maxHealth;
            _stamina = maxStamina;
        }

        private void Start()
        {
            StartCoroutine(NaturalRecoverStamina());
        }

        private IEnumerator NaturalRecoverStamina()
        {
            while (_isAlive)
            {
                var delta = Time.deltaTime;
                _recoveryTimer += delta;
                if (_recoveryTimer > recoveryTime)
                {
                    _stamina = Mathf.Min(_stamina + defaultStaminaRecovery * delta, maxStamina);
                    PlayerHUD.Instance.SetStamina(_stamina, maxStamina);
                }

                yield return null;
                if (_stamina >= maxStamina) yield return new WaitUntil(() => _stamina < maxStamina);
                else continue;
                _recoveryTimer = 0;
            }
        }

        /// <returns>Is Die</returns>
        public bool DecreaseHP(float value)
        {
            _health -= value;
            PlayerHUD.Instance.SetHealth(_health, maxHealth);
            if (_health <= 0) _isAlive = false;
            return _health <= 0;
        }

        /// <returns>Remaining Value</returns>
        public float IncreaseHP(float value)
        {
            _health += value;
            PlayerHUD.Instance.SetHealth(_health, maxHealth);
            return Mathf.Max(maxHealth - _health, 0);
        }

        /// <returns>Use Success</returns>
        public bool UseStamina(float value)
        {
            if (_stamina > value) return false;
            _stamina -= value;
            PlayerHUD.Instance.SetStamina(_stamina, maxStamina);
            return true;
        }
    }
}