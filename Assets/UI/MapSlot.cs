using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        GameMapManger.instance.GameUIPre.GetComponent<GameUI>().mapScipt.Save_Map_Name = map.Name; // ���������� �� �̸��� ���� 
        SceneManager.LoadScene("InGame");        
    }
}
