using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class JsonController : Singleton<JsonController>
{
    // Start is called before the first frame update

    public object getJsonObj(string jsonTag) 
    {
        object jsonObj = null;
        switch (jsonTag)
        {
            case "monster":
                jsonObj = getMonsterJson(); 
                break;
        }
        return jsonObj;
    }
    public object getMonsterJson() 
    {
        string jsonString = File.ReadAllText(Application.dataPath + "/Resources/Data/Monster.json");
        MonsterType monsterObject = JsonUtility.FromJson<MonsterType>(jsonString);
        Dictionary<string, Dictionary<string, Monster>> monsterType = new Dictionary<string, Dictionary<string, Monster>>();
        Dictionary<string, Monster> normal = new Dictionary<string, Monster>();
        Dictionary<string, Monster> elite = new Dictionary<string, Monster>();
        Dictionary<string, Monster> boss = new Dictionary<string, Monster>();
        //normal
        normal.Add("guy",monsterObject.normal.guy);
        //elite
        elite.Add("pinkguy", monsterObject.elite.pinkguy);
        elite.Add("powerguy", monsterObject.elite.powerguy);
        //boss
        boss.Add("superguy", monsterObject.boss.superguy);
        //Type
        monsterType.Add("normal",normal);
        monsterType.Add("elite", elite);
        monsterType.Add("boss", boss);
        return monsterType;
    }
}



[Serializable]
public class Monster
{
    public float HP;
    public float STR;
    public float AGI;
}
[Serializable]
public class Normal 
{
    public Monster guy;
}
[Serializable]
public class Elite
{
    public Monster pinkguy;
    public Monster powerguy;
}
[Serializable]
public class Boss
{
    public Monster superguy;
}
[Serializable]
public class MonsterType
{
    public Normal normal;
    public Elite elite;
    public Boss boss;
}
