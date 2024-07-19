using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class StartStoryOnCollision : MonoBehaviour
{
    [SerializeField] private TextAsset story;
    [SerializeField] private bool _IsStoryRepeatable = false;
    [SerializeField] private bool _TriggerAnimateOnEnter = false;
    [SerializeField] private string _PlayerAnimationTrigger = "Hello";
    [SerializeField] private bool _DestoyStoryOnExit = false;
    [SerializeField] private GameObject _DestoyThisObject;
    private bool _triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!_IsStoryRepeatable)
            {
                if (!_triggered)
                {
                    if (_TriggerAnimateOnEnter)
                    {
                        FindObjectOfType<ThirdPersonController>().GetComponent<Animator>().SetTrigger(_PlayerAnimationTrigger);
                    }
        
                    var storyView = FindObjectOfType<StoryView>(true);
                    if (storyView.isActiveAndEnabled)
                    {
                        return;
                    }

                    storyView.StartStory(story);
                    _triggered = true;   
                }    
            }
            else
            {
                if (_TriggerAnimateOnEnter)
                {
                    FindObjectOfType<ThirdPersonController>().GetComponent<Animator>().SetTrigger(_PlayerAnimationTrigger);
                }
        
                var storyView = FindObjectOfType<StoryView>(true);
                if (storyView.isActiveAndEnabled)
                {
                    return;
                }

                storyView.StartStory(story);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_DestoyStoryOnExit)
            {
                Destroy(_DestoyThisObject);   
            }
        }
    }
}
