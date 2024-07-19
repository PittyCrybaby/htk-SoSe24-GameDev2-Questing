using UnityEngine;

public class LockedByQuest : MonoBehaviour
{
    [SerializeField] private CollectionQuest quest;
    
    public CollectionQuest Quest => quest;
}