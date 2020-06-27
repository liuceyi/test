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

    private void Awake()
    {
        MsgCenterRabbitVer.Instance.SubscribeMessage("UpdateMainUI", UpdateUI);
    }

    private void OnDestroy()
    {
        MsgCenterRabbitVer.Instance.RemoveMessage("UpdateMainUI");
    }


    void UpdateUI() 
    {
        codeNickname.text = GameController.gameController.getNickname();
        codeMoney.text = GameController.gameController.getMoney().ToString();
        codeXp.text = GameController.gameController.getXp().ToString();
    }
    
}
