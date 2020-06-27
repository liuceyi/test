using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private string _playerNickname;
    private int _playerXp;
    private int _playerMoney;

    public GameController()
    {
        _playerNickname = "sakuyo";
        _playerXp = 0;
        _playerMoney = 100;
    }

    public int getMoney() 
    {
        return _playerMoney;
    }
    public void setMoney(int num) 
    {
        _playerMoney = num;
    }
    public int getXp()
    {
        return _playerXp;
    }
    public void setXp(int num)
    {
        _playerXp = num;
    }
    public string getNickname()
    {
        return _playerNickname;
    }
    public static GameController _gameController;
    public static GameController gameController
    {
        get 
        {
            if (_gameController == null)
            {
                _gameController = FindObjectOfType(typeof(GameController)) as GameController;
            }
            return _gameController;
        }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
