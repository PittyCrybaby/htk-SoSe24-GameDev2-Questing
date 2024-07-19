using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

[CreateAssetMenu]
public class CollectionQuest : ScriptableObject, IQuest
{
    public string displayName;
    public List<ItemRequirement> requirements;
    public bool isHidden;
    public GameObject completeScreenPrefab; // this is null by default. Optionally: a screen
    public PlayableAsset completePlayable;
    
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

    public PlayableAsset GetCompletePlayable()
    {
        return completePlayable;
    }

    [Serializable]
    public class ItemRequirement
    {
        public ItemType type;
        public uint amount = 1;
    }
}