using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MsgCenterRabbitVer : Singleton<MsgCenterRabbitVer>
{

    private Dictionary<string, Action<ArrayList>> dicMsg = new Dictionary<string, Action<ArrayList>>();


    public void Init()
    {
        dicMsg.Clear();
    }

    public void SubscribeMessage(string str, Action<ArrayList> call)
    {
        if (dicMsg.ContainsKey(str))
        {
            dicMsg[str] = call;
        }
        else
        {
            dicMsg.Add(str, call);
        }
    }

    public void RemoveMessage(string str)
    {
        if (dicMsg.ContainsKey(str))
        {
            dicMsg.Remove(str);
        }
    }
    //触发对应str的action，参数为arraylist中泛型的obj
    public void Publish(string str, ArrayList obj)
    {
        if (dicMsg.ContainsKey(str))
        {
            dicMsg[str].Invoke(obj);
        }
    }
}
