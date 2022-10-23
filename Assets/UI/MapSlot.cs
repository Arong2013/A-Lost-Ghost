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
    public void Start()
    {
        text.text = map.Name.ToString();
    }
    public void BtnsDown()
    {
        GameMapManger.instance.GameUIPre.GetComponent<GameUI>().mapScipt.Save_Map_Name = map.Name; // 프리팹으로 맵 이름을 저장 
        SceneManager.LoadScene("InGame");        
    }
}
