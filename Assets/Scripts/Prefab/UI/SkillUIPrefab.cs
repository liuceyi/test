using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUIPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    public void init(string skillName)
    {
        loadAssets(skillName);
    }
    void loadAssets(string name)
    {
        string assetPath = "Image/Skill/" + name;
        Sprite skillImage = Resources.Load<Sprite>(assetPath);
        GetComponent<Image>().sprite = skillImage;
    }
}
