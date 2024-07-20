using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LoadNextScene : Interactable



{
    [Header("Item Check")]
    [SerializeField] private ItemType _itemType;
    [SerializeField] private uint _amount;
    [Space]
    [SerializeField] private GameObject _player;
    [SerializeField] private float _wait;
    [Space]
    [Header("Animation")]
    [SerializeField] private GameObject _FindComponentOfThisObject;
    [SerializeField] private string _triggerAnotherAnimation;
    private Animator _AnotherAnimator;
    private bool _ObjectInteracted;
    
    private void Awake()
    {
        if (_FindComponentOfThisObject != null)
        {
            _AnotherAnimator = _FindComponentOfThisObject.GetComponent<Animator>();
        }
    }
    
    private IEnumerator Num()
    {
        yield return new WaitForSeconds(_wait);
        LoadScene();
    }

    public override void Interact()
    {
        Debug.Log("Door_Interact");
        if (!_ObjectInteracted)
        {
            _ObjectInteracted = true;
            if (GameState.HasEnoughItems(_itemType, _amount))
            {
                FindObjectOfType<PlayerInput>().actions.Disable();
                Debug.Log("ItemsEnough");
                _AnotherAnimator.SetTrigger(_triggerAnotherAnimation);
                StartCoroutine(Num());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _ObjectInteracted = false;
        }
    }

    private void LoadScene()
    {
        FindObjectOfType<PlayerInput>().actions.Enable();
        _player.transform.position = new Vector3(-340.83f, 17.062f, -370.02f);
        _player.transform.rotation = new Quaternion(0f, -31.99f, 0f,0f);
    }
}