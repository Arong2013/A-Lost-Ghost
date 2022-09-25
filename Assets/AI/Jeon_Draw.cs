using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using System.Linq;

public class Jeon_Draw : MonoBehaviour
{
    #region Singleton

    public static Jeon_Draw instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject); instance = this;
    }
    #endregion
    public enum Touching
    {
        Down,        
        Up,
    }

    public Tilemap Ground;
    public Tilemap Draw;
    public TileBase Color;

    [SerializeField]
    List<Vector3Int> Draw_Vectors;

    public Touching touching;
    public GameObject SkillPointPreFeb, SkillPointField;
    public bool SkillFinsh;
    float Sq1;
    Vector3 mouseInput;
    Vector3Int Pos;
    int x, y;
    bool check;


  
    public void TouchDown()
    {
        mouseInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        x = (int)mouseInput.x;
        y = (int)mouseInput.y;

        if (touching == Touching.Up)
        {
            SkillPointField = Instantiate(SkillPointPreFeb, new Vector2(x, y), this.transform.rotation);            
            touching = Touching.Down;                 
        }
    }

    public void TouchDrag()
    {
        if(touching == Touching.Down)
        {
            mouseInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            x = (int)mouseInput.x;
            y = (int)mouseInput.y;
            SkillPointField.transform.position = new Vector3Int(x, y, 0);
            Pos = new Vector3Int(x, y, 0);
            ChangeTile(Pos);
            
        }
    }

    public void TouchUp()
    {
        touching = Touching.Up;
        GameUI.instance.TouchUI.SetActive(false);
        Destroy(SkillPointField);
    }
    public void ChangeTile(Vector3Int AddTileVector)
    {
        Draw.SetTile(AddTileVector, null);
        Draw.SetTile(AddTileVector, Color);
        Draw_Vectors.Add(AddTileVector);
        Draw_Vectors = Draw_Vectors.Distinct().ToList();
       // Draw.SetTileFlags(Draw_Vectors[i], TileFlags.None);
        // Draw.SetColor(Draw_Vectors[i], new Color(255 / 255f, 255 / 255f, 255 / 255f, 0 / 255f));
    }
}
