using System.Collections;
using StarterAssets;
using UnityEngine;

public class ByPass : Interactable
{
    [SerializeField] private TextAsset _story;
    [Space]
    [Header("GameObjects")]
    [SerializeField] private GameObject _DeleteBlockator;
    [Space]
    [Header("Animations")]
    [SerializeField] private string _playerAnimationTrigger;
    [Space]
    [Header("WaitBefore")]
    [SerializeField] private float _wait;
    [Space]
    [Header("Has Item Check")]
    [SerializeField] private ItemType _itemType;
    [SerializeField] private uint _amount;
    [Space]
    [Header("GiveItems")]
    [SerializeField] private ItemType _itemTypeToGive;
    [SerializeField] private uint _amountToGive;

    private IEnumerator Num()
    {
        yield return new WaitForSeconds(_wait);
        Destroy(_DeleteBlockator);
        GameState.AddItem(_itemTypeToGive, _amountToGive);
    }
    public override void Interact()
    {
        if (GameState.HasEnoughItems(_itemType, _amount))
        {
            FindObjectOfType<ThirdPersonController>().GetComponent<Animator>().SetTrigger(_playerAnimationTrigger);
            StartCoroutine(Num());
        }
        
        else
        {
            var storyView = FindObjectOfType<StoryView>(true);
            if(storyView.isActiveAndEnabled)
            {
                return;
            }

            storyView.StartStory(_story);
        }
    }
}
