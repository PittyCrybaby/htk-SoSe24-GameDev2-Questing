using UnityEngine;

public class NormalUiView : MonoBehaviour
{
    [SerializeField] private PauseMenu pauseScreen;

    private void Update()
    {
        if (Input.GetButtonDown("Menu") && Time.timeScale > 0)
        {
            var storyView = FindObjectOfType<StoryView>(true);
            if (!storyView.isActiveAndEnabled)
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        UIService.Open(pauseScreen.gameObject);
    }
}