using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openable : Interactable
{
    [SerializeField] private Animator _animator;
    [SerializeField] private ItemType _requiredItem;
    [SerializeField] private uint _requiredAmount;
    [SerializeField] private bool _shouldConsume;
    private bool _isOpen;
    public override void Interact()
    {
        if (_isOpen)
        {
            return;
        }

        if (_shouldConsume)
        {
            if (GameState.TryRemoveItem(_requiredItem, _requiredAmount))
            {
                Open();
            }
        }
        else
        {
            if (GameState.HasEnoughItems(_requiredItem, _requiredAmount))
            {
                Open();
            }
        }
        
    }

    private void Open()
    {
        _isOpen = true;
        _animator.SetBool("isOpen", true);
    }

}