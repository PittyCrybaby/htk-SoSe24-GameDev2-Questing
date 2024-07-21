using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using DG.Tweening;
using FMODUnity;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Ink.UnityIntegration;

public class StoryView : MonoBehaviour
{
    
    //[Header("Global Ink File")]
    //[SerializeField] private InkFile _globalsInkFile;
    [Space]
    [Header("Dialog")]
    [SerializeField] private RectTransform choiceHolder;
    [SerializeField] private TextMeshProUGUI storyText;
    [SerializeField] private TextMeshProUGUI speakerName;
    [SerializeField] private Button buttonPrefab;
    [SerializeField] private GameObject normalHudGroup;
    [SerializeField] private Image speakerImage;
    [SerializeField] private GameObject _Melody;
    [SerializeField] private List<SpeakerConfig> speakerConfigs;
    
    //private DialogueVariables _dialogueVariables;
    
    //private UnityAction _onFinished; (53, 99, StoryNPC)

    [Serializable]
    public class SpeakerConfig
    {
        public string name;
        public string emotion;
        public Sprite sprite;
    }

    private Story story;
    private List<IQuest> _quests;
    private PlayerInput _playerInput;

    private void Awake()
    {
        DestroyOldChoices();
        gameObject.SetActive(false);
        _playerInput = FindObjectOfType<PlayerInput>();
        
        CollectionQuest[] collectionQuests = Resources.LoadAll<CollectionQuest>("Quests");
        _quests = new List<IQuest>();
        foreach (var collectionQuest in collectionQuests)
        {
            _quests.Add(collectionQuest);
        }

        //_dialogueVariables = new DialogueVariables(_globalsInkFile.filePath);
    }

    public void StartStory(TextAsset textAsset)
    {
        //UnityAction onFinished (Argument)
        //_onFinished = onFinished;
        //_Melody.GetComponent<StudioEventEmitter>().SetParameter("Dialog", 1);
        normalHudGroup.SetActive(false);
        _playerInput.currentActionMap = _playerInput.actions.FindActionMap("UI");
        _playerInput.actions.Disable();
        gameObject.SetActive(true);
        story = new Story(textAsset.text);
        
        //_dialogueVariables.StartListening(story);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        foreach (var quest in GameState.GetCompletableQuests())
        {
            var varName = "completable_" + quest.Quest.GetId().ToLower();
            if (story.variablesState.Contains(varName))
            {
                story.variablesState[varName] = true;
            }
        }

        foreach (var quest in GameState.GetCompletedQuests())
        {
            var varName = "completed_" + quest.Quest.GetId().ToLower();
            if (story.variablesState.Contains(varName))
            {
                story.variablesState[varName] = true;
            }
        }

        foreach (var quest in GameState.GetActiveQuests())
        {
            var varName = "active_" + quest.Quest.GetId().ToLower();
            if (story.variablesState.Contains(varName))
            {
                story.variablesState[varName] = true;
            }
        }

        ShowStory();
    }

    private void CloseStory()
    {
        //_Melody.GetComponent<StudioEventEmitter>().SetParameter("Dialog", 0);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
        normalHudGroup.SetActive(true);
        _playerInput.currentActionMap = _playerInput.actions.FindActionMap("Player");
        //_onFinished?.Invoke();
        
        //_dialogueVariables.StopListeting(story);
    }

    private void ShowStory()
    {
        DestroyOldChoices();

        // Read all the content until we can't continue any more
        while (story.canContinue)
        {
            // Continue gets the next line of the story
            string text = story.Continue();
            // This removes any white space from the text.
            text = text.Trim();
            CreateContentView(text); // Display the text on screen!
            HandleTags(); // For example: give new quests
        }

        if (story.currentChoices.Count > 0)
        {
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];
                Button button = CreateChoiceView(choice.text.Trim(), i);
                // Tell the button what to do when we press it
                button.onClick.AddListener(() => OnClickChoiceButton(choice));
            }
        }
        else
        {
            /*
            Button choice = CreateChoiceView("Continue", 0);
            choice.onClick.AddListener(CloseStory);
            */
            CloseStory();
        }
    }

    private void HandleTags()
    {
        if (story.currentTags.Count <= 0)
        {
            return;
        }

        foreach (var currentTag in story.currentTags)
        {
            if (currentTag.Contains("addQuest"))
            {
                var questName = currentTag.Split(' ')[1];
                var quest = _quests.First(q => string.Equals(q.GetId(), questName, StringComparison.OrdinalIgnoreCase));
                GameState.StartQuest(quest);
                FindObjectOfType<QuestLogView>(true).ShowActiveQuests();
            }

            if (currentTag.Contains("removeQuest"))
            {
                var questName = currentTag.Split(' ')[1];
                GameState.RemoveQuest(questName);
                FindObjectOfType<QuestLogView>(true).ShowActiveQuests();
            }

            if (currentTag.Contains("completeQuest"))
            {
                var questName = currentTag.Split(' ')[1];
                GameState.CompleteQuest(questName);
                FindObjectOfType<QuestLogView>(true).ShowActiveQuests();
            }
            
            if (currentTag.Contains("speaker"))
            {
                var speaker = currentTag.Split(' ')[1];
                var emotion = currentTag.Split(' ')[2];
                speakerName.text = speaker; 
                speakerImage.sprite = GetSpeakerImage(speaker, emotion);
            }
        }
    }

    private void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        ShowStory();
    }

    private void CreateContentView(string text)
    {
        if (story.globalTags != null)
        {
            var speaker = story.globalTags.FirstOrDefault(t => t.Contains("speaker"))?.Split(' ')[1];
            var speakerEmotion =  story.globalTags.FirstOrDefault(t => t.Contains("speaker"))?.Split(' ')[2];
            speakerName.text = speaker; 
            speakerImage.sprite = GetSpeakerImage(speaker, speakerEmotion);
        }
        StartCoroutine(ShowTextLetterByLetter(text));
    }

    IEnumerator ShowTextLetterByLetter(string text)
    {
        storyText.text = text;
        storyText.maxVisibleCharacters = 0;
        for (int i = 0; i <= text.Length; i++)
        {
            storyText.maxVisibleCharacters = i;
            if (_playerInput.actions["Skip"].WasPressedThisFrame())
            {
                storyText.maxVisibleCharacters = text.Length;
                yield break;
            }

            yield return new WaitForSeconds(0.015f); // wir könnten auch 1 sekunde warten, das wäre sehr langsam
        }
    }

    private Sprite GetSpeakerImage(string speaker, string emotion)
    {
        return speakerConfigs.FirstOrDefault(s => s.name == speaker && string.Equals(s.emotion.ToLower(), emotion.ToLower()))?.sprite;
    }

    private void DestroyOldChoices()
    {
        foreach (Transform child in choiceHolder)
        {
            Destroy(child.gameObject);
        }
    }

    private Button CreateChoiceView(string text, int index)
    {
        var choice = Instantiate(buttonPrefab, choiceHolder.transform, false);
        if (index == 0)
        {
            choice.Select();
        }

        choice.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBounce).From(0f).SetDelay(index * 0.2f);

        var choiceText = choice.GetComponentInChildren<TextMeshProUGUI>();
        choiceText.text = text;

        return choice;
    }
}