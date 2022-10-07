using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMapManger : MonoBehaviour
{
    #region Singleton

    public static GameMapManger instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject); instance = this;  
    }
    #endregion

    public GameObject GameUIPre; //게임 UI 맵 이름 저장 
}
