using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class shootController : MonoBehaviour
{
    
    //读取saw的预制体
    public GameObject sawPrefab;
    
    private List<GameObject> sawsList;//保存场上saw的list，最高不超过10个
    private int sawIndex; //场上存在的saw的数量
    public int sawMaxNum;//场上最多同时存在saw的数量
    public float sawSpeed;//saw的移动速度

    // Start is called before the first frame update
    private void Awake()
    {
        Action<ArrayList> call = new Action<ArrayList>(editSawIndex);
        MsgCenterRabbitVer.Instance.SubscribeMessage("EditSawIndex", editSawIndex);
    }
    private void OnDestroy()
    {
        MsgCenterRabbitVer.Instance.RemoveMessage("EditSawIndex");
    }

    void Start()
    {
        sawsList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            spawnSaw(Input.mousePosition);
        }
    }
    void spawnSaw(Vector3 mousePos)
    {
        sawIndex += 1;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        float throwAngle = Vector2.Angle(mousePos - this.transform.position, Vector2.up);

        if (mousePos.x > this.transform.position.x)
        {
            throwAngle = -throwAngle;
        }
        //在玩家位置生成saw
        GameObject sawClone = Instantiate(sawPrefab, transform.position, Quaternion.identity) as GameObject;
        //初始化saw速度
        sawClone.GetComponent<Rigidbody2D>().velocity = ((mousePos - transform.position).normalized * sawSpeed);
        //初始化saw运动角度
        sawClone.transform.eulerAngles = new Vector3(0, 0, throwAngle);
        sawsList.Add(sawClone);
        if (sawIndex > sawMaxNum)
        {
            //销毁数组中下标为0的游戏物体
            Destroy(sawsList[0]);
            sawIndex -= 1;
            //移除数组中已被销毁物体的 位置
            sawsList.RemoveAt(0);
            //  return;
        }
    }
    void editSawIndex(ArrayList obj) {
        int index = (int)(obj[0]);
        sawIndex += index;
        if (index < 0) 
        {
            Destroy(sawsList[0]);
            sawsList.RemoveAt(0);
        }
    }
}
