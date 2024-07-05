using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OpenUiButton : MonoBehaviour
{
    [SerializeField] private GameObject screen;
    
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OpenUI);
    }

    private void OpenUI()
    {
        UIService.Open(screen);
    }
}