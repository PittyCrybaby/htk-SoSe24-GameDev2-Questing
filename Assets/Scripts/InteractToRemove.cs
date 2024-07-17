using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractToRemove : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _deleteThisGameObject;
    public bool CanBeDeleted; 

    public void Interact()
    {
        if (CanBeDeleted)
        {
            Destroy(_deleteThisGameObject);   
        }
    }
}
