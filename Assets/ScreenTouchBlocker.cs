using System;
using Services.UIServices;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class ScreenTouchBlocker : ITickable
{
    public bool IsBlocked { get; private set; } = false;
    
    public void Tick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Input.mousePosition;

            if (clickPosition.x <= Screen.width / 2)
            {
                IsBlocked = true;
            }

            IsBlocked = false;
        }
    }
}