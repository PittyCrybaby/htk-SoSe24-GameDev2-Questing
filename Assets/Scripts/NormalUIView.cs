using UnityEngine;

public class NormalUIView : MonoBehaviour
{
    [SerializeField] private PauseMenu pauseScreen;

    private void Update()
    {
        if (Input.GetButtonDown("Menu") && Time.timeScale > 0)
        {
            Pause();
        }
    }

    private void Pause()
    {
        UIService.Open(pauseScreen.gameObject);
    }
}