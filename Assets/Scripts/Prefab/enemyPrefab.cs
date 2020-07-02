
using UnityEngine;
using UnityEngine.UI;

public class EnemyPrefab : MonoBehaviour
{
    public Slider HPBar;
    private GameObject player;
    private Animator anim;  //动画组件
    private string enemyName;
    
    private float _enemyHP;
    private float enemyHPFull;
    public float enemyHP 
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
    private bool isAlive;
    private bool hurting = false;
    private bool dying = false;
    private bool isBerserker = false;
    private bool isWarrior = false;
    // Start is called before the first frame update

    public void init(string name,GameObject target, Monster obj) 
    {
        enemyName = name;
        
        isAlive = true;
        player = target;
        enemyHP = obj.HP;
        enemyHPFull = enemyHP;
        enemySTR = obj.STR;
        enemyAGI = obj.AGI;
        anim = GetComponent<Animator>();

        loadAssets(enemyName);
        loadBuff();
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
        if (isAlive)
        {
            if (player && (!hurting || isWarrior)) 
            {
                Vector3 playerPos = player.transform.position;
                GetComponent<Rigidbody2D>().velocity = ((playerPos - transform.position).normalized * enemyAGI);
            }
        
            Vector2 enemyPosition = Camera.main.WorldToScreenPoint(transform.position);
            HPBar.transform.position = enemyPosition + new Vector2(0, 60);
        }
        
    }
    void loadBuff() 
    {
        switch (enemyName)
        {
            case "superguy":
                isBerserker = true;
                break;
            case "powerguy":
                isWarrior = true;
                break;
        }
    }
    void updateHPBar() 
    {
        HPBar.value = enemyHP / enemyHPFull;
        if (isBerserker && HPBar.value <= 0.3) enemyAGI *= 1.3f;
    }
    void beingHurt() 
    {
        hurting = false;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        var tag = collider.tag;
        Debug.Log(tag);
        if (tag == "Player") 
        {
            //敌人撞到玩家
            
            PlayerController.Instance.getHurt(enemySTR);
        }
        if (tag == "Attack") 
        {
            hurting = true;
            Invoke("beingHurt", 0.2f);
            //敌人被击中
            anim.SetTrigger("hurt");
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Destroy(collider.gameObject);
            if (enemyHP <= 0 && !dying) 
            {
                dying = true;
                anim.SetBool("die",true);
                // 销毁当前游戏物体
                BattleController.Instance.getScore(1);
                //销毁攻击物体（子弹类）
                Destroy(HPBar);
                isAlive = false;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
                //Destroy(gameObject);
            }
        }
        
        
    }

}
