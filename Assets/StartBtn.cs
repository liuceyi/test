using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class StartBtn : MonoBehaviour
{
    public GameObject imgFrogWait;
    
    private Animator anim;
    private AnimatorStateInfo animatorInfo;



    // Start is called before the first frame update
    void Start()
    {
        
        

    }
    public void OnButtonClick()
    {
        GameObject imgFrogHit = (GameObject)Resources.Load("Prefabs/img_frog_hit");
        
        Destroy(imgFrogWait);

        Instantiate(imgFrogHit);

        imgFrogHit.SetActive(true);

        anim = imgFrogHit.GetComponent<Animator>();
        print(anim.GetCurrentAnimatorStateInfo(0));
        
        
        //anim.SetBool("animationRun", true);
        //Debug.Log("hello sakuyo");
        //SceneManager.LoadScene("home");
    }
    // Update is called once per frame
    void Update()
    {
        if (anim && anim.runtimeAnimatorController) 
        {
            animatorInfo = anim.GetCurrentAnimatorStateInfo(0);//获取动画信息

            if (animatorInfo.normalizedTime >= 1.0f)
            {
                //播放完毕，要执行的内容
                print("hello sakuyo");
            }
        }

    }
}
