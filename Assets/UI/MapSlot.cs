using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class MapSlot : MonoBehaviour
{
    public Maps map;
    [SerializeField]
    Text text;
   
    public List<Image> Stars;


    public void Start()
    {
        text.text = map.Name.ToString();
        for(int i =0; i<GameUI.instance.mapScipt.maps.Count; i++)
            if(GameUI.instance.mapScipt.maps[i].Name == map.Name)
            {
                for (int k = 0; k < GameUI.instance.mapScipt.maps[i].Stars.Count; k++)
                    Stars[k].sprite = GameUI.instance.mapScipt.maps[i].Stars[k];
            }
    }
    public void BtnsDown()
    {
        if(!map.Lock)
        {
            GameUI.instance.mapScipt.Save_Map_Name = map.Name; // 프리팹으로 맵 이름을 저장 
            SceneManager.LoadScene("InGame");
        }
            
    }
}
