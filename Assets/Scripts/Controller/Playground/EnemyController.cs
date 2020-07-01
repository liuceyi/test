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
    public float time = 0.5f;
    public List<String> enemySpawnList;//怪物刷新列表
    public float enemySpeed;//enemy的移动速度
    public float enemyHP;//enemy的HP
    Dictionary<string, Dictionary<string, Monster>> enemyData = new Dictionary<string, Dictionary<string, Monster>>();
    public List<Vector2> enemyStationList;//enemy的出生点列表
    private bool updated = false;
    
    // Start is called before the first frame update
    void Start()
    {
        int wave = GameController.gameController.targetWave;
        textWin.SetActive(false);
        btnRestart.SetActive(false);
        btnBackHome.SetActive(false);
        enemyData = (Dictionary<string, Dictionary<string, Monster>>)JsonManager.GetComponent<jsonManager>().getJsonObj("monster");
        enemyStationList = new List<Vector2>();
        enemyStationList.Add(new Vector2(0, 0));
        enemyStationList.Add(new Vector2(1260, 0));
        enemyStationList.Add(new Vector2(0, 600));
        enemyStationList.Add(new Vector2(1260, 600));
        string[] wave1 = { "normal-guy", "normal-guy", "normal-guy", "elite-pinkguy", "normal-guy", "normal-guy", "normal-guy", 
                           "elite-pinkguy", "elite-pinkguy", "elite-pinkguy", "normal-guy", "normal-guy", "normal-guy","elite-pinkguy" };
        string[] wave2 = { "normal-guy", "normal-guy", "normal-guy", "elite-pinkguy", "elite-powerguy", "normal-guy", "normal-guy",
                           "elite-pinkguy", "elite-pinkguy", "elite-pinkguy", "normal-guy", "elite-powerguy", "elite-powerguy","elite-pinkguy",
                           "elite-pinkguy","elite-pinkguy","elite-pinkguy","elite-pinkguy","elite-pinkguy","elite-pinkguy","elite-pinkguy"};
        string[] wave3 = { "normal-guy", "normal-guy", "normal-guy", "elite-pinkguy", "elite-powerguy", "elite-powerguy", "normal-guy",
                           "elite-pinkguy", "elite-pinkguy", "elite-pinkguy", "normal-guy", "elite-powerguy", "elite-powerguy","elite-pinkguy",
                           "elite-pinkguy","elite-powerguy","elite-powerguy","elite-powerguy","elite-powerguy","elite-powerguy","boss-superguy"};
        List<string[]> waveList = new List<string[]>();
        waveList.Add(wave1);
        waveList.Add(wave2);
        waveList.Add(wave3);
        enemySpawnList.AddRange(waveList[wave-1]);

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (enemySpawnList.Count == 0) 
        {
            CancelInvoke("waitForSpawnEnemy");
            if (!updated && EnemyList.transform.childCount == 0) 
            {
                updated = true;
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
        //关卡结算
        if(GameController.gameController.targetWave < 3 && GameController.gameController.targetWave > GameController.gameController.wave)
        GameController.gameController.wave += 1;
        //关卡通过自动保存
        PlayerSave.Instance.gameSave();
        //弹出胜利UI
        textWin.SetActive(true);
        btnRestart.SetActive(true);
        btnBackHome.SetActive(true);
    }
    public void StartSpawnEnemy()
    {
        Destroy(BtnStart);

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

    }



}
