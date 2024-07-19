using System;
using System.Collections;
using StarterAssets;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class Collectable : Interactable
{
    [Header("Item To Give")]
    [SerializeField] private ItemType _type;
    [SerializeField] private uint _amount = 1;
    [Space]
    [SerializeField] private UnityEvent _onCollect;
    [SerializeField] private bool _trowStory;
    [SerializeField] private TextAsset _story;
    [Space]
    [Header("Animation")]
    [SerializeField] private string _playerAnimationTrigger = "PickUp";
    [SerializeField] private float _wait;

    private PlayerInput _playerInput;
    private ThirdPersonController _ThirdPersonController;
    private bool _ObjectInteracted = false;
    private void Awake()
    {
        _playerInput = FindObjectOfType<PlayerInput>();
        _ThirdPersonController = FindObjectOfType<ThirdPersonController>();
    }

    private IEnumerator Num()
    {
        yield return new WaitForSeconds(_wait);
        if (!_trowStory)
        {
            _playerInput.actions.Enable();
            Destroy(gameObject);
        }
        else
        {
            Read();
            Destroy(gameObject);
        }
    }
    public override void Interact()
    {
        if (!_ObjectInteracted)
        {
            _ObjectInteracted = true;  
            Debug.Log("Collected "+ name);

            GameState.AddItem(_type, _amount);
            _ThirdPersonController.GetComponent<Animator>().SetTrigger(_playerAnimationTrigger);
            _playerInput.actions.Disable();
            _onCollect?.Invoke();
            StartCoroutine(Num());   
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _ObjectInteracted = false;
        }
    }
    
    private void Read()
    {
        var storyView = FindObjectOfType<StoryView>(true);
        if (storyView.isActiveAndEnabled)
        {
            return;
        }
        storyView.StartStory(_story);
    }
}