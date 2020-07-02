using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIController : MonoBehaviour
{
    public GameObject scoreBoard;
    public GameObject textBattle;
    public GameObject btnRestart;
    public GameObject btnBackHome;
    public GameObject btnStart;
    public GameObject enemyController;
    public void gameStart() 
    {
        btnStart.SetActive(false);
        enemyController.GetComponent<EnemyController>().StartSpawnEnemy();
    }
    public void updateScore(float score)
    {
        scoreBoard.GetComponent<ScoreController>().score = score;
    }
    public void gameOver()
    {
        //弹出失败UI
        textBattle.SetActive(true);
        textBattle.GetComponent<Text>().text = "You lose !";
        btnRestart.SetActive(true);
        btnBackHome.SetActive(true);
        
    }
    public void GameWin()
    {
        //弹出胜利UI
        textBattle.SetActive(true);
        btnRestart.SetActive(true);
        btnBackHome.SetActive(true);
    }
}   
