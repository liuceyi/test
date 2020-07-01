using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PublicTool
{
    public static void changeAttribute(PlayerAttribute attribute, int num) 
    {
        switch (attribute) 
        {
            case PlayerAttribute.Money:
                GameController.gameController.playerMoney += num;
                break;
            case PlayerAttribute.Xp:
                GameController.gameController.playerXp += num;
                break;

        }

        MsgCenterRabbitVer.Instance.Publish("UpdateMainUI",new ArrayList {123,"sakuyo" });
    }
    //sakuyo branch is here
    //general method
}
