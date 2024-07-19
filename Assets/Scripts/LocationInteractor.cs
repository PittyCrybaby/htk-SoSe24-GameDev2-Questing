using QuickOutline;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocationInteractor : MonoBehaviour
{
    private Interactable _currentInteractable;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = FindObjectOfType<PlayerInput>();
    }

    private void Update()
    {
        if (_currentInteractable != null)
        {
            if (_playerInput.actions["Interact"].WasPressedThisFrame())
            {
                _currentInteractable?.Interact();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered");
        if (other.TryGetComponent<Interactable>(out var interactable))
        {
            Debug.Log("entered interactable");
            _currentInteractable = interactable;
        }
        
        if (other.TryGetComponent<Outline>(out var outline))
        {
            outline.enabled = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("entered");
        if (other.TryGetComponent<Interactable>(out var interactable))
        {
            if (_currentInteractable == interactable)
            {
                Debug.Log("entered interactable");
                _currentInteractable = null;
            }
        }
        
        if (other.TryGetComponent<Outline>(out var outline))
        {
            outline.enabled = false;
        }
    }
}