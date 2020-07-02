using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPrefab : MonoBehaviour
{
    private Animator anim;  //动画组件
    public float damage = 1;

    // Start is called before the first frame update
    public void init(string skillName)
    {
        anim = GetComponent<Animator>();
        loadAssets(skillName);
        loadDamage(skillName);
    }
    
    void loadAssets(string name)
    {
        string assetPath = "Anim/Player/Skill/" + name+"/";
        RuntimeAnimatorController animController = Resources.Load<RuntimeAnimatorController>(assetPath + name);
        anim.runtimeAnimatorController = animController;

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        var tag = collider.tag;
        Debug.Log(tag);
        if (tag == "Enemy")
        {
            //敌人被击中
            collider.gameObject.GetComponent<EnemyPrefab>().enemyHP -= damage;
        }


    }
    void loadDamage(string name) 
    {
        Dictionary<string,float> skillDamageDict= new Dictionary<string,float>();
        skillDamageDict.Add("Giant Saw", 3);
        damage = skillDamageDict[name];
    }
}
