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

        private BaseMover _currentBaseMover;
        private readonly Dictionary<MoveType, BaseMover> _movers = new Dictionary<MoveType, BaseMover>();

        private enum MoveType
        {
            Default,
            Combat
        }

        private void Awake()
        {
            _animator = transform.GetChild(transform.childCount-1).GetComponent<Animator>();
            _playerStats = GetComponent<PlayerStats>();

            var movers = transform.GetChild(0).GetComponents<BaseMover>();
            _movers.Add(MoveType.Default, _currentBaseMover = movers[0]);
            _movers.Add(MoveType.Combat, movers[1]);
        }

        private void Update()
        {
            _playerInput.UpdateInput();
            _currentBaseMover?.Move(_playerInput.Direction, transform, _animator);
            
            //TODO: Test
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _currentBaseMover = _currentBaseMover == _movers[MoveType.Combat] ? _movers[MoveType.Default] : _movers[MoveType.Combat];
            }
        }
    }
}