using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[CreateAssetMenu]
public class CollectionQuest : ScriptableObject, IQuest
{
    public string displayName;
    public List<ItemRequirement> requirements;
    public bool isHidden;
    public GameObject completeScreenPrefab; //this is null by default. Opitonally: a screen

    public string GetId()
    {
        return name;
    }

    public bool IsHidden()
    {
        return isHidden;
    }

    public string GetDisplayName()
    {
        return displayName;
    }

    public GameObject GetCompleteScreenPrefab()
    {
        return completeScreenPrefab;
    }

    [Serializable]
    public class ItemRequirement
    {
        public ItemType type;
        public uint amount = 1;
    }
}