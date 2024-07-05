using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    [SerializeField] private PauseMenu pauseScreen;

    private void Awake()
    {
        closeButton.onClick.AddListener(Close);
        closeButton.Select();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Menu"))
        {
            Close();
        }
    }

    private void Close()
    {
        // the options menu exists in the game scene and the main menu, we only want to reopen the pause menu in the game scene
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            UIService.Open(pauseScreen.gameObject);
        }
        Destroy(gameObject);
    }
}