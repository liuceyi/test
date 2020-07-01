using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CanvasShowController : MonoBehaviour
{
    public GameObject enemyShowPrefab;
    private int wave;
    // Start is called before the first frame update
    
    public void updateCanvas()
    {
        for (int i = transform.childCount-1; i >=0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
        wave = GameController.gameController.targetWave;
        string[] wave1 = {"guy","pinkguy"};
        string[] wave2 = { "guy", "pinkguy", "powerguy" };
        string[] wave3 = { "guy", "pinkguy", "powerguy" , "superguy" };

        List<string[]> waveEnemyList = new List<string[]>();
        waveEnemyList.Add(wave1);
        waveEnemyList.Add(wave2);
        waveEnemyList.Add(wave3);

        for (int i = 0; i < waveEnemyList[wave-1].Length; i++)
        {
            createEnemyShow(waveEnemyList[wave-1][i]);
        }
        
        
        
        
    }
    void createEnemyShow(string enemyStr) 
    {
        
        GameObject enemyShowUnit = Instantiate(enemyShowPrefab);
        enemyShowUnit.transform.SetParent(transform);
        enemyShowUnit.GetComponent<enemyShow>().init(enemyStr);

    }
    // Update is called once per frame

}
