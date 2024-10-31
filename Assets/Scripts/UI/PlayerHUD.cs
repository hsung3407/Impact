using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayerHUD : MonoBehaviour
    {
        [SerializeField] private Slider hpBar;

        private void Awake()
        {
            hpBar.minValue = 0;
            hpBar.maxValue = 1;
        }

        private void SetHP(float value) => hpBar.value = value;
        private void SetHP(float value, float maxValue) => hpBar.value = value / maxValue;
    }
}