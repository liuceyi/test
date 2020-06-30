using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnGoPlay : MonoBehaviour
{
    // Start is called before the first frame update

    public void goPlay() 
    {
        SceneManager.LoadScene("Playground");
    }
    // Update is called once per frame

}
