using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MsgCenterRabbitVer : Singleton<MsgCenterRabbitVer>
{

    public Dictionary<string, UnityAction> dicMsg = new Dictionary<string, UnityAction>();


    public void Init()
    {
        dicMsg.Clear();
    }

    public void SubscribeMessage(string str, UnityAction call)
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

    public void Publish(string str)
    {
        if (dicMsg.ContainsKey(str))
        {
            dicMsg[str].Invoke();
        }
    }
}
