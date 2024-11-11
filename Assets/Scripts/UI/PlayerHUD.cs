using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Utility;

namespace UI
{
    public class PlayerHUD : Singleton<PlayerHUD>
    {
        [SerializeField] private Slider healthBar;
        [SerializeField] private Slider staminaBar;


        public void SetHealth(float value, float maxValue) =>
            healthBar.value = value / maxValue * healthBar.maxValue + healthBar.minValue;

        public void SetStamina(float value, float maxValue) =>
            staminaBar.value = value / maxValue * staminaBar.maxValue + staminaBar.minValue;
    }
}