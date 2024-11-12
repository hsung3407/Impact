using System;
using System.Collections.Generic;
using Player.Mover;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private Animator _animator;
        private PlayerStats _playerStats;

        private readonly PlayerInput _playerInput = new PlayerInput();

        private MoverBase _mover;

        private void Awake()
        {
            var character = transform.GetChild(transform.childCount - 1);
            _animator = character.GetComponent<Animator>();
            _mover = character.GetComponent<MoverBase>();
            _playerStats = GetComponent<PlayerStats>();
        }

        private void Update()
        {
            _playerInput.UpdateInput();
            _mover?.Move(_playerInput.Direction, transform, _animator);
            
            //TODO: Test
            if (Input.GetKeyDown(KeyCode.U))
            {
                _playerStats.UseStamina(10);
            }
        }
    }
}