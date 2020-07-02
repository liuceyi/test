using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawPrefab : MonoBehaviour
{
    public float damage = 1;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 posNow = Camera.main.ScreenToWorldPoint(this.transform.position);
        if (posNow.x > 1260 || posNow.x < 0 || posNow.y > 600 || posNow.y < 0) 
        {
            Destroy(gameObject);
            
        }
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
}
