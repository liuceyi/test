using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreController : MonoBehaviour
{
    public Text codeScore;
    private float _score;
    public float score
    {
        get { return _score; }
        set 
        {
            _score = value;
            codeScore.text = value.ToString();
        }
    
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
