using System;
using UnityEngine;
using UnityEngine.InputSystem;

using Player.Movement;

namespace Player
{
    [RequireComponent(typeof(PlayerInput))]
    public sealed class InputParser : MonoBehaviour
    {
        [SerializeField] private Walk walk;
        [SerializeField] private Jump jump;
        
        private PlayerInput _playerInput;
        private InputActionAsset _inputActionAsset;
        
        private void Awake()
        {
            GetReferences();
            Init();
        }

        private void Update()
        {
            Vector2 input = _inputActionAsset["Move"].ReadValue<Vector2>();
            walk.SetInput(input);
        }

        private void OnEnable() => AddListeners();

        private void OnDisable() => RemoveListeners();

        private void GetReferences()
        {
            _playerInput = GetComponent<PlayerInput>();
        }

        private void Init() => _inputActionAsset = _playerInput.actions;

        private void AddListeners()
        {
            _inputActionAsset["Jump"].performed += JumpAction;
        }

        private void RemoveListeners()
        {
            _inputActionAsset["Jump"].performed -= JumpAction;
        }
        
        #region Context
        
        private void JumpAction(InputAction.CallbackContext context) => jump.DoJump();

        #endregion
    }
}