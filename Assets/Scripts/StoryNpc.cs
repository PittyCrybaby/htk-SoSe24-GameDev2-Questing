using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

/*public class StoryNpc : MonoBehaviour, IInteractable
{
    [SerializeField] private TextAsset _story;

    public void Interact()
    {
        var storyView = FindObjectOfType<StoryView>(true);
        if(storyView.isActiveAndEnabled)
        {
            return;
        }

        storyView.StartStory(_story);
    }
    
}*/

public class StoryNpc : Interactable
{
    [SerializeField] private TextAsset story;
    [SerializeField] private bool _animateIT;
    [SerializeField] private string _playerAnimationTrigger = "Hello";
    [SerializeField] private bool _EnableCollider;
    [SerializeField] private GameObject _gameObject;

    private bool _ColliderEnabled = false;

    private bool _ObjectInteracted = false;
    /*private void Start()
    {
        var closeupCamera = GetComponentInChildren<Camera>(true);
        if (closeupCamera != null)
        {
            closeupCamera.gameObject.SetActive(false);
        }
    }*/

    public override void Interact()
    {
        if (!_ObjectInteracted)
        {
            _ObjectInteracted = true;

            if (_animateIT)
            {
                FindObjectOfType<ThirdPersonController>().GetComponent<Animator>().SetTrigger(_playerAnimationTrigger);
            }

            var closeupCamera = GetComponentInChildren<Camera>(true);
            if (closeupCamera != null)
            {
                closeupCamera.gameObject.SetActive(true);
            }

            var storyView = FindObjectOfType<StoryView>(true);
            if (storyView.isActiveAndEnabled)
            {
                return;
            }

            storyView.StartStory(story);
            if (_EnableCollider && !_ColliderEnabled)
            {
                (_gameObject.GetComponent(typeof(BoxCollider)) as BoxCollider).isTrigger = true;
                _ColliderEnabled = true;
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
}