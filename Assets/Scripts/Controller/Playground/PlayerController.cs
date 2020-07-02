using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoSingleton<PlayerController>
{
    
    public GameObject HPBar;
    private Animator anim;  //动画组件
    private Rigidbody2D rig;

    //玩家的基础属性

    public float HP = 5;//玩家的血量
    public float playerAGI;//玩家的移动速度
    public float unhurtTime = 1;//玩家的无敌时间
    // 玩家的输入信息
    private float moveHorizontal;
    private float moveVertical;
    private Vector2 movement;
    
    
    //玩家的移动边界
    public float xMax, xMin, yMax, yMin;
    
    public Enums.movementType movementType;
    private bool moveable = true;//玩家的移动控制开关
    private bool beingHurt = false;
    // Start is called before the first frame update

    void Start()
    {

        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        movementType = Enums.movementType.AllDirections;
        
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        
        movement = new Vector2(moveHorizontal, moveVertical);
        switchAnim();
    }
    void FixedUpdate()
    {
        if (moveable)
        {
            float fx = Mathf.Clamp(transform.position.x + moveHorizontal * playerAGI, xMin, xMax);
            float fy = Mathf.Clamp(transform.position.y + moveVertical * playerAGI, yMin, yMax);
            //改变坐标实现移动（个人认为更顺滑）
            transform.position = new Vector2(fx, fy);
        }
        else 
        {
            transform.position = new Vector2(0, 0);
        }
        


    }
    public void AGIUp(float index, float time) 
    {
        playerAGI += index;
    }
    public void AGIDown(float index, float time) 
    {
        playerAGI -= index;
    }
    public void getHurt(float damage) 
    {
        HP -= damage;
        if (HP <= 0)
        {
            //停止移动
            HPBar.GetComponent<HPBarController>().clear();
            anim.SetBool("die", true);
            moveable = false;
            BattleController.Instance.gameOver();
            Destroy(gameObject);
            return;
        }
        if (beingHurt) return;
        beingHurt = true;//触发无敌时间
        HPBar.GetComponent<HPBarController>().hurt(damage);
        anim.SetTrigger("isHurt");
        StartCoroutine(recoverState());


    }
    IEnumerator recoverState() 
    {
        yield return new WaitForSeconds(unhurtTime);
        beingHurt = false;
        //解除无敌
    }



    void switchAnim() {
        if (moveHorizontal > 0)              // 播放向右走动画
        {
            anim.SetBool("isRight", true);
            anim.SetBool("isLeft", false);
            //正向
            transform.localScale = new Vector2(300f, 300f);
        }
        else if (moveHorizontal < 0)         // 播放向左走动画
        {
            anim.SetBool("isLeft", true);
            anim.SetBool("isRight", false);
            //镜像
            transform.localScale = new Vector2(-300f, 300f);
        }
        else                                 //静止 Idle 动画
        {
            anim.SetBool("isRight", false);
            anim.SetBool("isLeft", false);
        }        
    }
}
public class Enums
{
    public enum movementType
    {
        AllDirections,
        OnlyHorizontal,
        OnlyVertical
    }
}