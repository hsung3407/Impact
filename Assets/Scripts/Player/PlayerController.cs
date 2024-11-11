using System;
using System.Collections.Generic;
using Player.Mover;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerStats _playerStats;

        private readonly PlayerInput _playerInput = new PlayerInput();
        
        private IMover _currentMover;
        private readonly Dictionary<MoveType, IMover> _movers = new Dictionary<MoveType, IMover>();
        private enum MoveType
        {
            Default,
            Combat
        }

        private void Awake()
        {
            _playerStats = GetComponent<PlayerStats>();
            
            _movers.Add(MoveType.Default, _currentMover = new DefaultMover());
            _movers.Add(MoveType.Combat, new CombatMover());
        }

        private void Update()
        {
            _currentMover.Move(_playerInput.GetDirection(), transform);
        }
    }
}