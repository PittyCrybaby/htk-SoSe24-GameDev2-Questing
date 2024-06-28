using UnityEngine;

namespace DefaultNamespace
{
    public interface IQuest
    {
        public string GetId();
        public bool IsHidden();
        string GetDisplayName();
        GameObject GetCompleteScreenPrefab();
    }
}