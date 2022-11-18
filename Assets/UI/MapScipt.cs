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
}
