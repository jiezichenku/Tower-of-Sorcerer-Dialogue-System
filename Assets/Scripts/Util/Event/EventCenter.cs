using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCenter
{
    public static Dictionary<EventType, Delegate> eventTable = new Dictionary<EventType, Delegate>();

    //Add Listener 
    public static void AddListenerCheck(EventType eventType, Delegate callBack)
    {
        if (!eventTable.ContainsKey(eventType))
        {
            eventTable.Add(eventType, null);
        }
        //check the delegate invalid
        Delegate d = eventTable[eventType];
        if (d != null && d.GetType() != callBack.GetType())
        {
            throw new Exception("Invalid delegate");
        }
    }
    //Listener for different number of parameters
    public static void AddListener(EventType eventType, CallBack callBack)
    {
        AddListenerCheck(eventType, callBack);
        eventTable[eventType] = (CallBack)eventTable[eventType] + callBack;
    }
    public static void AddListener<T>(EventType eventType, CallBack<T> callBack)
    {
        AddListenerCheck(eventType, callBack);
        eventTable[eventType] = (CallBack<T>)eventTable[eventType] + callBack;
    }
    public static void AddListener<T, U>(EventType eventType, CallBack<T, U> callBack)
    {
        AddListenerCheck(eventType, callBack);
        eventTable[eventType] = (CallBack<T, U>)eventTable[eventType] + callBack;
    }
    //Remove Listener
    public static void RemoveListenerCheck(EventType eventType, Delegate callBack)
    {
        //Check event type and delegate
        if (eventTable.ContainsKey(eventType))
        {
            Delegate d = eventTable[eventType];
            if (d == null)
            {
               throw new Exception("No delegate to remove");
            }
            else if (d.GetType() != callBack.GetType())
            {
                throw new Exception("invalid delegate");
            }
        }
        else
        {
            throw new Exception("Event type not existed");
        }
    }
    public static void RemoveListener(EventType eventType, CallBack callBack)
    {
        RemoveListenerCheck(eventType, callBack);
        eventTable[eventType] = (CallBack)eventTable[eventType] - callBack;
    }

    public static void RemoveListener<T>(EventType eventType, CallBack<T> callBack)
    {
        RemoveListenerCheck(eventType, callBack);
        eventTable[eventType] = (CallBack<T>)eventTable[eventType] - callBack;
    }

    public static void RemoveListener<T, U>(EventType eventType, CallBack<T, U> callBack)
    {
        RemoveListenerCheck(eventType, callBack);
        eventTable[eventType] = (CallBack<T, U>)eventTable[eventType] - callBack;
    }

    //Broadcast
    public static void Broadcast(EventType eventType)
    {
        Delegate d;
        if (eventTable.TryGetValue(eventType, out d))
        {
            Debug.Log(d.Method.ReturnType);
            ((CallBack)d)?.Invoke();
        }
    }
    public static void Broadcast<T>(EventType eventType, T arg)
    {
        Delegate d;
        if (eventTable.TryGetValue(eventType, out d))
        {
            ((CallBack<T>)d)?.Invoke(arg);
        }
    }
    public static void Broadcast<T, U>(EventType eventType, T arg1, U arg2)
    {
        Delegate d;
        if (eventTable.TryGetValue(eventType, out d))
        {
            ((CallBack<T, U>)d)?.Invoke(arg1, arg2);
        }
    }
    public static bool Check(EventType eventType)
    {
        Delegate d;
        return eventTable.TryGetValue(eventType, out d);
    }
}
