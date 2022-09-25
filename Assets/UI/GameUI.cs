using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using System.Linq;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Maps
{
    public string Name;
    public GameObject Map;
}

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
    public Slider slider;
    public int SliderV;

    [SerializeField]
    List<Maps> maps;


    public GameObject MapSelectUI;

    public void Start()
    {
        SliderV = 1000;
    }
    public void DrawBtns_Down()
    {
        TouchUI.SetActive(true);
        if(Jeon_Draw.instance.what == Jeon_Draw.What.Draw)
        {
            Jeon_Draw.instance.what = Jeon_Draw.What.Remove;
        }
        else
        {
            Jeon_Draw.instance.what = Jeon_Draw.What.Draw;
        }
        Jeon_Draw.instance.touching = Jeon_Draw.Touching.Up;
    }

    public void Update()
    {
        if(slider != null)
        {
            slider.value = SliderV;
        }       
    }






    public void StartBtns()
    {
        MapSelectUI.SetActive(true);
        SoundManger.instance.SFXplay("Click");
    }

    public void HomeBtns()
    {
        MapSelectUI.SetActive(false);
        SoundManger.instance.SFXplay("Click");
    }

    public void MapSelect(string Name)
    {
        for(int i =0; i<maps.Count; i++)
        {
            if (Name == maps[i].Name)
            {
                
            }
        }
       
    }
}
