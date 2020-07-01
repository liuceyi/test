using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public Text codeNickname;
    public Text codeMoney;
    public Text codeXp;
    // Start is called before the first frame update

    private void Awake()
    {
        Action<ArrayList> call = new Action<ArrayList>(UpdateUI);
        MsgCenterRabbitVer.Instance.SubscribeMessage("UpdateMainUI", UpdateUI);
        UpdateUI(new ArrayList { 123, "sakuyo" });
    }

    private void OnDestroy()
    {
        MsgCenterRabbitVer.Instance.RemoveMessage("UpdateMainUI");
    }


    void UpdateUI(ArrayList obj) 
    {
        codeNickname.text = GameController.gameController.playerNickname;
        codeMoney.text = GameController.gameController.playerMoney.ToString();
        codeXp.text = GameController.gameController.playerXp.ToString();
        print("Trigger Message：" + obj[0] + obj[1]);
    }
    
}
