using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private InputActionProperty _inputGrip;
    [SerializeField] private InputActionProperty _inputTrigger;

    private void Start()
    {
        _inputGrip.action.performed += Grip;
        _inputGrip.action.canceled += Grip;

        _inputTrigger.action.performed += Trigger;
        _inputTrigger.action.canceled += Trigger;
    }

    private void OnDisable()
    {
        _inputGrip.action.performed -= Grip;
        _inputGrip.action.canceled -= Grip;

        _inputTrigger.action.performed -= Trigger;
        _inputTrigger.action.canceled -= Trigger;
    }

    private void Grip(InputAction.CallbackContext context) => _animator.SetFloat("Grip", context.ReadValue<float>());

    private void Trigger(InputAction.CallbackContext context) => _animator.SetFloat("Trigger", context.ReadValue<float>());
}