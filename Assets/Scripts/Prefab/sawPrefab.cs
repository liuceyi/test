using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 posNow = Camera.main.ScreenToWorldPoint(this.transform.position);
        if (posNow.x > 1260 || posNow.x < 0 || posNow.y > 600 || posNow.y < 0) 
        {
            Destroy(gameObject);
            
        }
    }
}
