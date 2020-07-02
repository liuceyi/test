
using UnityEngine;

public class ShootController : MonoBehaviour
{
    
    //读取saw的预制体
    public GameObject sawPrefab;
    public GameObject SawsList;//空的父物体，用于储存saw
    public int sawMaxNum;//场上最多同时存在saw的数量
    public float sawSpeed;//saw的移动速度


    // Start is called before the first frame update


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
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        float throwAngle = Vector2.Angle(mousePos - this.transform.position, Vector2.up);

        if (mousePos.x > this.transform.position.x)
        {
            throwAngle = -throwAngle;
        }
        //在玩家位置生成saw
        GameObject sawClone = Instantiate(sawPrefab, transform.position, Quaternion.identity) as GameObject;
        //将生成的saw装入空的父物体SawsList，便于计数
        sawClone.transform.parent = SawsList.transform;
        //初始化saw速度
        sawClone.GetComponent<Rigidbody2D>().velocity = ((mousePos - transform.position).normalized * sawSpeed);
        //初始化saw运动角度
        //sawClone.transform.eulerAngles = new Vector3(0, 0, throwAngle);

        if (SawsList.transform.childCount > sawMaxNum)
        {
            //销毁数组中下标为0的游戏物体
            Destroy(SawsList.transform.GetChild(0).gameObject);

           
            //  return;
        }
    }

}
