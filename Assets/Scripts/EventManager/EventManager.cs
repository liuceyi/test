using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager
{
    static EventManager() 
    {
        if (eventManager == null) 
        {
            eventManager = new EventManager();
        }

    }
    private static EventManager eventManager;
    private Dictionary<EventType, object> eventDic = new Dictionary<EventType, object>();
}
