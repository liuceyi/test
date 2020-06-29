using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject player;
    public GameObject EnemyList;//储存Enemy的空的父物体

    public int enemyMaxNum;//场上最多同时存在enemy的数量

    public float enemySpeed;//enemy的移动速度
    public float enemyHP;//enemy的HP
    public List<String> enemyData;
    public List<Vector2> enemyStationList;//enemy的出生点列表

    // Start is called before the first frame update
    void Start()
    {
        enemyStationList = new List<Vector2>();
        enemyStationList.Add(new Vector2(0, 0));
        enemyStationList.Add(new Vector2(1260, 0));
        enemyStationList.Add(new Vector2(0, 600));
        enemyStationList.Add(new Vector2(1260, 600));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            spawnEnemy();
        }
    }
    void spawnEnemy()
    {

        //在生成点位置生成enemy
        GameObject enemyClone = Instantiate(enemyPrefab, enemyStationList[0], Quaternion.identity) as GameObject;
        enemyClone.transform.parent = EnemyList.transform;
        enemyClone.GetComponent<enemyPrefab>().init(player,enemySpeed,enemyHP);

        if (EnemyList.transform.childCount > enemyMaxNum)
        {
            //销毁数组中下标为0的游戏物体
            Destroy(EnemyList.transform.GetChild(0).gameObject);


        }
    }



}
