using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPrefab : MonoBehaviour
{
    private GameObject player;
    private float enemySpeed = 20;
    private float enemyHP = 1;
    // Start is called before the first frame update

    public void init(GameObject target,float speed,float HP) 
    {
        enemySpeed = speed;
        player = target;
        enemyHP = HP;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerPos = player.transform.position;
        GetComponent<Rigidbody2D>().velocity = ((playerPos - transform.position).normalized * enemySpeed);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        var tag = collider.tag;
        Debug.Log(tag);
        if (tag == "Player") 
        {
            //敌人撞到玩家
            Debug.Log("kill player");
            player.GetComponent<PlayerController>().getHurt(1);
        }
        if (tag == "Attack") 
        {
            Debug.Log("kill enemy");
            //敌人被击中
            enemyHP -= 1;
            if (enemyHP <= 0) 
            {
                // 销毁当前游戏物体
                player.GetComponent<PlayerController>().getScore(1);
                //销毁攻击物体（子弹类）
                Destroy(collider);
                Destroy(gameObject);
            }
        }
        
        
    }

}
