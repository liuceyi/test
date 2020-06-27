using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public Text codeNickname;
    public Text codeMoney;
    public Text codeXp;
    // Start is called before the first frame update

    void UpdateUI() 
    {
        codeNickname.text = GameController.gameController.getNickname();
        codeMoney.text = GameController.gameController.getMoney().ToString();
        codeMoney.text = GameController.gameController.getXp().ToString();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
