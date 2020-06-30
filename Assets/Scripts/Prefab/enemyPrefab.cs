
using UnityEngine;
using UnityEngine.UI;

public class enemyPrefab : MonoBehaviour
{
    public Slider HPBar;
    private GameObject player;
    private Animator anim;  //动画组件
    private string enemyName;
    
    private float _enemyHP;
    private float enemyHPFull;
    private float enemyHP 
    {
        get
        {
            return _enemyHP;
        } 
        set 
        {
            _enemyHP = value;
            updateHPBar();
        } 
    }
    private float enemySTR = 1;
    private float enemyAGI = 1;
    
    // Start is called before the first frame update

    public void init(string name,GameObject target, Monster obj) 
    {
        enemyName = name;

        player = target;
        enemyHP = obj.HP;
        enemyHPFull = enemyHP;
        enemySTR = obj.STR;
        enemyAGI = obj.AGI;
        anim = GetComponent<Animator>();

        loadAssets(enemyName);
    }
    void loadAssets(string name) 
    {
        string assetPath = "Anim/Enemy/" + name+"/";
        RuntimeAnimatorController animController = Resources.Load<RuntimeAnimatorController>(assetPath + name);
        anim.runtimeAnimatorController = animController;
        if (name == "powerguy") 
        {
            transform.localScale = new Vector3(500,500,1); 
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (player) 
        {
            Vector3 playerPos = player.transform.position;
            GetComponent<Rigidbody2D>().velocity = ((playerPos - transform.position).normalized * enemyAGI * 40);
        }
        
        Vector2 enemyPosition = Camera.main.WorldToScreenPoint(transform.position);
        HPBar.transform.position = enemyPosition + new Vector2(0, 60);
    }
    void updateHPBar() 
    {
        HPBar.value = enemyHP / enemyHPFull;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        var tag = collider.tag;
        Debug.Log(tag);
        if (tag == "Player") 
        {
            //敌人撞到玩家
            
            player.GetComponent<PlayerController>().getHurt(enemySTR);
        }
        if (tag == "Attack") 
        {
            
            //敌人被击中
            enemyHP -= 1;
            anim.SetTrigger("hurt");
            Destroy(collider.gameObject);
            if (enemyHP <= 0) 
            {
                anim.SetBool("die",true);
                // 销毁当前游戏物体
                player.GetComponent<PlayerController>().getScore(1);
                //销毁攻击物体（子弹类）
                
                //Destroy(gameObject);
            }
        }
        
        
    }

}
