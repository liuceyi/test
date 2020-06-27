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
                int money = GameController.gameController.getMoney();
                GameController.gameController.setMoney(money + num);
                break;
            case PlayerAttribute.Xp:
                int Xp = GameController.gameController.getXp();
                GameController.gameController.setXp(Xp + num);
                break;

        }
    }
    //sakuyo branch is here
    //general method
}
