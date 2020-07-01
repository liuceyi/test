using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnWave : MonoBehaviour
{
    private int targetWave;
    // Start is called before the first frame update
    public void init(int wave)
    {
        targetWave = wave;
    }
    public void onclick() 
    {
        GameController.gameController.targetWave = targetWave;
        transform.parent.GetComponent<CanvasBtnController>().activeShowCanvas();
    }
    // Update is called once per frame

}
