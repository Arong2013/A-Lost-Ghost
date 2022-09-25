using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{

    #region Singleton

    public static GameUI instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject); instance = this;
    }
    #endregion



    public GameObject TouchUI,DrawBtns;

    public void DrawBtns_Down()
    {
        TouchUI.SetActive(true);
        Jeon_Draw.instance.touching = Jeon_Draw.Touching.Up;
    }
}
