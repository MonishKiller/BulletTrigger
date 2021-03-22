using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventMangaer : MonoBehaviour
{
    public static EventMangaer current;
    private void Awake()
    {
        current = this;

    }
    public event Action OnhitTriggerEnter;
    public void HitTrigger()
    {
        if (OnhitTriggerEnter != null)
        {
            OnhitTriggerEnter(); 
        }

    }
}
