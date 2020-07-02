
using UnityEngine;

public class BattleController : MonoSingleton<BattleController>
{
    public int score;
    public GameObject battleUIController;
    
    void Start()
    {
        
    }
    public void gameStart() 
    {
        battleUIController.GetComponent<BattleUIController>().gameStart();
    }
    public void getScore(int scoreAdd) 
    {
        score += scoreAdd;
        battleUIController.GetComponent<BattleUIController>().updateScore(score);
    }
    public void gameOver() 
    {
        battleUIController.GetComponent<BattleUIController>().gameOver();
    }
    public void gameWin()
    {
        //根据得分增加经验，金币
        PublicTool.changeAttribute(PlayerAttribute.Xp, 1 * score);
        PublicTool.changeAttribute(PlayerAttribute.Money, 100 * score);
        //关卡结算
        if (GameController.gameController.targetWave < 3 && GameController.gameController.targetWave > GameController.gameController.wave)
            GameController.gameController.wave += 1;
        //关卡通过自动保存
        PlayerSave.Instance.gameSave();

        battleUIController.GetComponent<BattleUIController>().GameWin();
    }
}
