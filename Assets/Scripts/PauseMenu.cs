using System;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject PausePanel;
        [SerializeField] private Button ContinueButton;

        private void Awake()
        {
            PausePanel.SetActive(false);
            ContinueButton.onClick.AddListener(() => SetPausedStatus(false));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                var wasPreviouslyPaused = PausePanel.activeSelf;
                SetPausedStatus(!wasPreviouslyPaused);
            }
        }
        
        private void SetPausedStatus(bool isPaused)
        {
            PausePanel.SetActive(isPaused);
            Time.timeScale = isPaused ? 0 : 1;
            Cursor.visible = isPaused;
            Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }