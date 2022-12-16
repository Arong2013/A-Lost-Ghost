using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class MapScipt : ScriptableObject
{
    public List<Maps> maps;
    public Sprite Fill_Star, Non_Fill_Star;



    public string Save_Map_Name;


    public void Starts()
    {
        for (int i = 0; i < maps.Count; i++)
            for (int s = 0; s < maps[i].Stars.Count; s++)
                maps[i].Stars[s] = Non_Fill_Star;
            
    }

    public void Star_Add()
    {
        for (int i = 0; i < maps.Count; i++)
        {
            maps[i].Stars.Clear();
            for (int k = 0; k < 3; k++)
            {
                maps[i].Stars.Add(Non_Fill_Star);
            }
        }
          
          
    }
}
