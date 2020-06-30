using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarController : MonoBehaviour
{
    public GameObject player;
    public GameObject HPPrefab;
    private float HP;
    // Start is called before the first frame update
    void Start()
    {
        //init
        HP = player.GetComponent<PlayerController>().HP;
        for (int i = 0; i < HP; i++)
        {
            Instantiate(HPPrefab, transform);
            
        }
    }
    public void setHP(float value) 
    {
        HP = value;
        if (HP <= 0) return;
        for (int i = 0; i < HP; i++)
        {
            GameObject heart = Instantiate(HPPrefab);
            heart.transform.SetParent(transform);
        }
    }
    // Update is called once per frame
    public void hurt(float damage) 
    {
        
        for (int i = 0; i < damage; i++)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
    void Update()
    {
        
    }
}
