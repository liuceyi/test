using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    public GameObject imgFrogWait;
    
    private Animator anim;
    private AnimatorStateInfo animatorInfo;
    private Boolean isEnd;


    // Start is called before the first frame update
    void Start()
    {
        
        

    }
    public void OnButtonClick()
    {
        GameObject imgFrogHit = (GameObject)Resources.Load("Prefabs/img_frog_hit");
        
        Destroy(imgFrogWait);

        imgFrogHit = Instantiate(imgFrogHit);
        isEnd = false;
        //imgFrogHit.SetActive(true);

        anim = imgFrogHit.GetComponent<Animator>();
        
        
        
        //anim.SetBool("animationRun", true);
        //Debug.Log("hello sakuyo");
        //SceneManager.LoadScene("home");
    }
    // Update is called once per frame
    void Update()
    {
        UnityEngine.Debug.Log(GameController.gameController.getMoney()); 
        if (anim && anim.runtimeAnimatorController && !isEnd) 
        {
            animatorInfo = anim.GetCurrentAnimatorStateInfo(0);//获取动画信息

            if (animatorInfo.normalizedTime >= 1.0f)
            {
                isEnd = true;
                //播放完毕，要执行的内容
                print("hello sakuyo");
                SceneManager.LoadScene("home");
            }
        }

    }
}
