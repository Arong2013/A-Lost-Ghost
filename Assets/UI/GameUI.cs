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
    public int stageindex;
    public GameObject[] StagePrefab;
    public Jeon_Players Player;
    GameObject Stage;


    [SerializeField]
    List<Maps> maps;


    public GameObject MapSelectUI;

    public void Start()
    {
        SliderV = 1000;
        Stage = Instantiate(StagePrefab[stageindex], new Vector3(0, 0, -1), Quaternion.Euler(0, 0, 0)); // prefab형태 맵 생성
        Stage.SetActive(true);
    }

    void OnCollisionEnter2D(Collision2D collision) // jang_ 추가 낙하했을때 되돌리기
    {
        if(collision.transform.tag == "Player")
        {

            collision.transform.position = new Vector3(0, 0, -1);

        }
        
    }
    public void NextStage() // jang_ stage 넘기기 
    {
        if(stageindex < 3)
        {

            //SceneManager.LoadScene("InGame " + stageindex++);
           
            
            //GameObject addStage = Instantiate(Stage);
            Destroy(Stage); // 현재 prefab 맵 삭제
            stageindex++;
            Stage = Instantiate(StagePrefab[stageindex]); // 다음 스테이지 생성
            Stage.SetActive(true); 
            //stageindex++;
            //GameObject instance = Instantiate(Resources.Load("Stage" + stageindex, typeof(GameObject))) as GameObject;
            Player.Reposition();
            Debug.Log(stageindex);
        }
        else
        {
            Debug.Log("clear");
        }
        
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
