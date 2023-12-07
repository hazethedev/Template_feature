using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

namespace hazethedev.InputSystem
{
    public class InputReader : MonoBehaviour
    {
        private PlayerInputActions m_PlayerInputActions;
        private IMovementInputReceiver[] m_InputReceivers;

        private void Awake()
        {
            m_PlayerInputActions = new();
            m_InputReceivers = FindObjectsOfType<MonoBehaviour>().OfType<IMovementInputReceiver>().ToArray();
        }

        private void OnEnable()
        {
            RegisterListeners();
            m_PlayerInputActions.Enable();
        }

        private void OnDisable()
        {
            UnregisterListeners();
            m_PlayerInputActions.Disable();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void OnInputStarted(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();
            
            foreach (var receiver in m_InputReceivers)
                receiver.OnInputStart(in value);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void OnInputPerformed(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();
            
            foreach (var receiver in m_InputReceivers)
                receiver.OnInputPerform(in value);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void OnInputCanceled(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();
            
            foreach (var receiver in m_InputReceivers)
                receiver.OnInputCancel(in value);
        }
        
        private void RegisterListeners()
        {
            var movementInputAction = m_PlayerInputActions.Player.Movement;
            
            movementInputAction.started   += OnInputStarted;
            movementInputAction.performed += OnInputPerformed;
            movementInputAction.canceled  += OnInputCanceled;
        }
        
        private void UnregisterListeners()
        {
            var movementInputAction = m_PlayerInputActions.Player.Movement;
            
            movementInputAction.started   -= OnInputStarted;
            movementInputAction.performed -= OnInputPerformed;
            movementInputAction.canceled  -= OnInputCanceled;
        }
    }
}