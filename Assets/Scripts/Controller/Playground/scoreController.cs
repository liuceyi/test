using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
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
}
