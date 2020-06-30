using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject player;
    public GameObject EnemyList;//储存Enemy的空的父物体
    public GameObject JsonManager;
    public GameObject BtnStart;
    public GameObject scoreBoard;
    public GameObject textWin;
    public GameObject btnRestart;
    public GameObject btnBackHome;
    public int time = 2;
    public List<String> enemySpawnList;//怪物刷新列表
    public float enemySpeed;//enemy的移动速度
    public float enemyHP;//enemy的HP
    Dictionary<string, Dictionary<string, Monster>> enemyData = new Dictionary<string, Dictionary<string, Monster>>();
    public List<Vector2> enemyStationList;//enemy的出生点列表
    //private bool isSpawning = false;
    
    // Start is called before the first frame update
    void Start()
    {
        textWin.SetActive(false);
        btnRestart.SetActive(false);
        btnBackHome.SetActive(false);
        enemyData = (Dictionary<string, Dictionary<string, Monster>>)JsonManager.GetComponent<jsonManager>().getJsonObj("monster");
        enemyStationList = new List<Vector2>();
        enemyStationList.Add(new Vector2(0, 0));
        enemyStationList.Add(new Vector2(1260, 0));
        enemyStationList.Add(new Vector2(0, 600));
        enemyStationList.Add(new Vector2(1260, 600));

        enemySpawnList.Add("normal-guy");
        enemySpawnList.Add("normal-guy");
        enemySpawnList.Add("normal-guy");
        enemySpawnList.Add("elite-pinkguy");
        enemySpawnList.Add("normal-guy");
        enemySpawnList.Add("normal-guy");
        enemySpawnList.Add("normal-guy");
        enemySpawnList.Add("elite-pinkguy");
        enemySpawnList.Add("elite-powerguy");
        enemySpawnList.Add("normal-guy");
        enemySpawnList.Add("normal-guy");
        enemySpawnList.Add("normal-guy");
        enemySpawnList.Add("elite-powerguy");
        enemySpawnList.Add("boss-superguy");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (enemySpawnList.Count == 0) 
        {
            CancelInvoke("waitForSpawnEnemy");
            if (EnemyList.transform.childCount == 0) 
            {
                GameWin();
            }
        } 
    }
    public void GameWin() 
    {
        //根据得分增加经验，金币
        int score = (int)scoreBoard.GetComponent<scoreController>().score;
        PublicTool.changeAttribute(PlayerAttribute.Xp, 1 * score);
        PublicTool.changeAttribute(PlayerAttribute.Money, 100 * score);
        //弹出胜利UI
        textWin.SetActive(true);
        btnRestart.SetActive(true);
        btnBackHome.SetActive(true);
    }
    public void StartSpawnEnemy()
    {
        Destroy(BtnStart);
        
        //spawnEnemy(enemySpawnList[0]);
        InvokeRepeating("waitForSpawnEnemy",0,time);
        

        
                                  
        

        
        
    }
    void waitForSpawnEnemy() 
    {
        
        if ( enemySpawnList.Count > 0)
        {
            
            spawnEnemy(enemySpawnList[0]);
            
        }
    }
    void spawnEnemy(string enemyStr)
    {
        
        if (enemyStr == "") 
        {
            Debug.Log("error:nothing in spawnEnemy");
            return;
        }
        string[] enemyStrList = enemyStr.Split('-');
        string enemyType = enemyStrList[0];
        string enemyName = enemyStrList[1];

        //在生成点位置生成enemy
        Debug.Log("Spawn");
        int ranNum = UnityEngine.Random.Range(0, 3);
        GameObject enemyClone = Instantiate(enemyPrefab, enemyStationList[ranNum], Quaternion.identity);
        
        enemyClone.transform.parent = EnemyList.transform;
        enemyClone.GetComponent<enemyPrefab>().init(enemyName, player, enemyData[enemyType][enemyName]);
        
        enemySpawnList.RemoveAt(0);
        //isSpawning = false;

        //if (EnemyList.transform.childCount > enemyMaxNum)
        //{
        //    //销毁数组中下标为0的游戏物体
        //    Destroy(EnemyList.transform.GetChild(0).gameObject);


        //}
    }



}
