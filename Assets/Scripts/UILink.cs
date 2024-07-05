using UnityEngine;

public class UILink : MonoBehaviour
{
    [SerializeField] private GameObject screen;
    private GameObject _screenInstance;

    public void Open()
    {
        _screenInstance = UIService.Open(screen);
    }
    
    public void Close()
    {
        if (_screenInstance != null)
        {
            Destroy(_screenInstance.gameObject);
        }
    }
}