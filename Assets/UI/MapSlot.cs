using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSlot : MonoBehaviour
{
    public Maps map;
    public void BtnsDown()
    {
        GameMapManger.instance.GameUIPre.GetComponent<GameUI>().Map_Name = map.Name; // ���������� �� �̸��� ���� 
        SceneManager.LoadScene("InGame");        
    }
}
