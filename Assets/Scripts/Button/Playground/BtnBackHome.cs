using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnBackHome : MonoBehaviour
{
    // Start is called before the first frame update

    public void backHome()
    {
        SceneManager.LoadScene("home");
    }
    // Update is called once per frame

}