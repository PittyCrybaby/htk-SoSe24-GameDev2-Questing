using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private OptionsMenu optionsMenuPrefab;
    
    private void Awake()
    {
        Pause();
        continueButton.onClick.AddListener(Continue);
        optionsButton.onClick.AddListener(OpenOptions);
        continueButton.Select();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Menu"))
        {
            Continue();
        }
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            continueButton.Select();
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        FindObjectOfType<PlayerInput>().enabled = false;
    }

    private void Continue()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Destroy(gameObject);
        FindObjectOfType<PlayerInput>().enabled = true;
    }
    
    private void OpenOptions()
    {
        UIService.Open(optionsMenuPrefab.gameObject);
        Destroy(gameObject);
    }
}