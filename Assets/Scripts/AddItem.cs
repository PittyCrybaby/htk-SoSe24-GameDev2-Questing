using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour
{
    [Header("GiveItems")]
    [SerializeField] private ItemType _itemTypeToGive;
    [SerializeField] private uint _amountToGive;
    private bool _gived = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!_gived)
            {
                _gived = true;
                GameState.AddItem(_itemTypeToGive, _amountToGive);
            }
        }
    }
}
