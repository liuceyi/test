using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestButtonDaji : MonoBehaviour
{
    public Button btnAddMoney;
    public Button btnAddXP;


    private void Awake()
    {
        btnAddMoney.onClick.RemoveAllListeners();
        btnAddMoney.onClick.AddListener(delegate ()
        {
            PublicTool.changeAttribute(PlayerAttribute.Money, 100);
        });

        btnAddXP.onClick.RemoveAllListeners();
        btnAddXP.onClick.AddListener(AddXP);
    }


    void AddXP()
    {
        PublicTool.changeAttribute(PlayerAttribute.Xp, 1);
    }
    void SakuyoTest()
    {
        //xixixixi

    }
}
