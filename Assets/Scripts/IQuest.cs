using UnityEngine;
using UnityEngine.Playables;

    public interface IQuest
    {
        public string GetId();
        public bool IsHidden();
        string GetDisplayName();
        GameObject GetCompleteScreenPrefab();
        PlayableAsset GetCompletePlayable();
    }