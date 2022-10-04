using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSlot : MonoBehaviour
{
    public Maps map;
    public void BtnsDown()
    {
        GameObject Maps = Instantiate(map.Map);
        SceneManager.LoadScene("InGame");        
        DontDestroyOnLoad(Maps);
    }
}
