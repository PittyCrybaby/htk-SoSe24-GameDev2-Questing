using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class LocationInteractor : MonoBehaviour
{
    [CanBeNull] private IInteractable _currentInteractable;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = FindObjectOfType<PlayerInput>();
    }

    private void Update()
    {
        if (_playerInput.actions["Interact"].WasPressedThisFrame())
        {
            _currentInteractable?.Interact();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
        {
            _currentInteractable = interactable;
        }
        
        if (other.TryGetComponent<Outline>(out var outline))
        {
            outline.enabled = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
        {
            if (_currentInteractable == interactable)
            {
                _currentInteractable = null;
            }
        }
        
        if (other.TryGetComponent<Outline>(out var outline))
        {
            outline.enabled = false;
        }
    }
}