using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public GameObject skillPrefab;
    public GameObject skillUIPrefab;
    public GameObject skillBoard;
    private string[] skillList;
    Dictionary<string, List<Skill>> skillData = new Dictionary<string, List<Skill>>();
    // Start is called before the first frame update
    void Start()
    {
        skillList = GameController.gameController.skillList;
        skillData = (Dictionary<string, List<Skill>>)JsonController.Instance.getJsonObj("skill");
        buildSkillBoard();
    }
    void buildSkillBoard() 
    {
        for (int i = 0; i < skillList.Length; i++)
        {
            GameObject skillUIUnit = Instantiate(skillUIPrefab);
            skillUIUnit.GetComponent<SkillUIPrefab>().init(skillList[i]);
            skillUIUnit.transform.SetParent(skillBoard.transform);
        }
    }

    void useSkill(int index) 
    {
        string skill = skillList[index];
        switch (skill)
        {
            case "Giant Saw":
                spawnAttackSkill(skill,Input.mousePosition,100f);
                break;
            case "Speed Up":
                spawnSupportSkill(skill,10f);
                break;
        }
    }
    void spawnAttackSkill(string skillName,Vector3 mousePos , float skillSpeed) 
    {
        List<Skill> attackSkillList = skillData["Attack"];
        Skill skillUnit = new Skill();
        for (int i = 0; i < attackSkillList.Count; i++)
        {
            if (attackSkillList[i].Name == skillName) 
            {
                skillUnit = attackSkillList[i];
            }
        }
        //TimeController cdTimer = new TimeController(skillUnit.CD);

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 playerPos = PlayerController.Instance.transform.position;
        float throwAngle = Vector2.Angle(mousePos - playerPos, Vector2.up);

        if (mousePos.x > playerPos.x)
        {
            throwAngle = -throwAngle;
        }
        //在玩家位置生成skill
        GameObject skillInstance = Instantiate(skillPrefab, playerPos, Quaternion.identity);
        skillPrefab.GetComponent<SkillPrefab>().init(skillName);
        //初始化skill速度
        skillInstance.GetComponent<Rigidbody2D>().velocity = ((mousePos - playerPos).normalized * skillUnit.Speed);
        


    }
    void spawnSupportSkill(string skillName,float time) 
    {
        PlayerController.Instance.AGIUp(3,time);
    }
    // Update is called once per frame

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            useSkill(0);
        }


    }
}
