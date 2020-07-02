using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShow : MonoBehaviour
{
    private string enemyName;
    private Animator anim;  //动画组件
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void init(string name) 
    {
        enemyName = name;
        anim = GetComponent<Animator>();
        loadAssets(enemyName);
    }
    void loadAssets(string name)
    {
        string assetPath = "Anim/Enemy/" + name + "/";
        RuntimeAnimatorController animController = Resources.Load<RuntimeAnimatorController>(assetPath + name+"_show");
        anim.runtimeAnimatorController = animController;
        if (name == "powerguy")
        {
            transform.localScale = new Vector3(300, 300, 1);
        }
    }
    // Update is called once per frame

}
