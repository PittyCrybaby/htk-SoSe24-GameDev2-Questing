using System;
using UnityEngine;
using Object = UnityEngine.Object;

public static class UIService
{
    public static GameObject Open(GameObject screen)
    {
        var uiRoot = Object.FindObjectOfType<UIRoot>();
        if (uiRoot == null)
        {
            throw new Exception("No UIRoot found in scene");
        }
        
        return Object.Instantiate(screen, uiRoot.transform);
    }
}