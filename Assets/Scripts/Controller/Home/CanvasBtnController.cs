using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasBtnController : MonoBehaviour
{
    public GameObject waveBtnPrefab;
    public GameObject btnGo;
    public GameObject canvasShow;
    public GameObject canvasShowGroup;
    // Start is called before the first frame update
    void Start()
    {

        int wave = GameController.gameController.wave;
        for (int i = 0; i < wave+1; i++)
        {
            GameObject waveBtn = Instantiate(waveBtnPrefab);
            waveBtn.GetComponent<btnWave>().init(i+1);
            waveBtn.transform.SetParent(transform);
            waveBtn.GetComponentInChildren<Text>().text = "wave " + (i+1);
        }
    }

    // Update is called once per frame
    public void activeShowCanvas() 
    {
        btnGo.SetActive(true);
        canvasShow.SetActive(true);
        canvasShowGroup.GetComponent<CanvasShowController>().updateCanvas();
    }

}
