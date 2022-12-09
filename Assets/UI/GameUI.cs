using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class Maps
{
    public string Name;
    public string BGM_Name;
    public GameObject Map;
    public List<Sprite> Stars;
    public bool Lock = true;
}

public class GameUI : MonoBehaviour
{
    enum WhatScean
    {
        Stage,
        Lobby
    }


    public static GameUI instance;
    #region Singleton



    void Awake()
    {
        instance = this;
        this.gameObject.GetComponent<GameUI>().enabled = true;
        if (whatScean == WhatScean.Stage) // 스테이지라면 맵 생성 
        {
            for (int i = 0; i < mapScipt.maps.Count; i++)
                if (mapScipt.maps[i].Name == mapScipt.Save_Map_Name)
                {
                    Instantiate(mapScipt.maps[i].Map);
                    SoundManger.instance.BGMplay(mapScipt.maps[i].BGM_Name);
                }
        }
        else if (whatScean == WhatScean.Lobby)
        {
            if (MapSlot != null) // 맵 슬롯이 없다면 맵의 개수 만큼 슬롯 생성 = 맵 선택화면에서 스테이지 보이기 위해 
                for (int i = 0; i < mapScipt.maps.Count; i++)
                {
                    GameObject map = Instantiate(MapSlot, MapParent.transform);
                }

        }


        if (MapParent != null)
        {
            for (int i = 0; i < MapParent.transform.childCount; i++)
            {
                mapSlots.Add(MapParent.transform.GetChild(i).GetComponent<MapSlot>());
                MapParent.transform.GetChild(i).GetComponent<MapSlot>().map = mapScipt.maps[i];
            }
        }
    }
    #endregion


    [FoldoutGroup("Scean")]
    [SerializeField]
    WhatScean whatScean;
    [FoldoutGroup("Scean")]
    public GameObject Fade;
    [FoldoutGroup("Scean")]
    [SerializeField]
    Image Logo, Loby;
    [FoldoutGroup("Scean")]
    [SerializeField]
    GameObject LobyUI;
    [FoldoutGroup("Scean")]
    [SerializeField]
    Sprite Pen, Eraser;
    [FoldoutGroup("Scean")]
    [SerializeField]
    Image InScrean;
    [FoldoutGroup("Scean")]
    [SerializeField]
    RawImage backGround1, backGround2;

    [FoldoutGroup("Map")]
    public GameObject MapParent, MapSlot;
    [FoldoutGroup("Map")]
    [SerializeField]
    public MapScipt mapScipt;
    [FoldoutGroup("Map")]
    [SerializeField]
    List<MapSlot> mapSlots;

    [FoldoutGroup("UI")]
    public GameObject TouchUI, DrawBtns, TouchFalseUI, Options, ClearUI;
    [FoldoutGroup("UI")]
    public Slider slider;
    [FoldoutGroup("UI")]
    [SerializeField]
    TextMeshProUGUI Map_Clear_Name;
    [FoldoutGroup("UI")]
    [SerializeField]
    List<Image> Stars;
    [FoldoutGroup("UI")]
    [SerializeField]
    List<Image> Clear_Stars;

    public MapScipt ScriptaOBmap;


    public float SliderV; // 맵 그리기 양
    public string Cun_Map;

    bool Esc;




    public GameObject MapSelectUI;

    public List<Rigidbody2D> Stone;


    [SerializeField]
    int mapChangeCount;
    bool isUp = true;
    public void Start()
    {
        Cun_Map = mapScipt.Save_Map_Name;
        SliderV = 1000; //  그리기 쓰면 지워지는 것 
        if (whatScean == WhatScean.Stage)
        {
            StartCoroutine(Start_Scene());
            Map_Clear_Name.text = mapScipt.Save_Map_Name;
        }
        else if (whatScean == WhatScean.Lobby)
        {
            SoundManger.instance.BGMplay("Main");
            Logo.DOColor(new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f), 2f);
        }

    }


    void OnCollisionEnter2D(Collision2D collision) // jang_ 추가 낙하했을때 되돌리기
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.position = new Vector3(0, 0, -1);
        }

    }
    public void DrawBtns_Down() // 그리기
    {
        TouchUI.SetActive(true);
        if (Jeon_Draw.instance.what == Jeon_Draw.What.Draw)
        {
            InScrean.sprite = Eraser;
            Jeon_Draw.instance.what = Jeon_Draw.What.Remove;
        }
        else
        {
            InScrean.sprite = Pen;
            Jeon_Draw.instance.what = Jeon_Draw.What.Draw;
        }
        Jeon_Draw.instance.touching = Jeon_Draw.Touching.Up;
    }

    public void Update()
    {
        if (slider != null)
        {
            slider.value = SliderV;
        }
        if (whatScean == WhatScean.Stage)
        {
            if (SliderV <= 800)
                Stars[0].DOColor(new Color(0, 0, 0, 0), 2f);
            if (SliderV <= 500)
                Stars[1].DOColor(new Color(0, 0, 0, 0), 2f);
            if (SliderV <= 200)
                Stars[2].DOColor(new Color(0, 0, 0, 0), 2f);
        }

        if (backGround1 != null && backGround1.transform.parent.gameObject.activeSelf)
        {
            if (isUp)
                mapChangeCount++;
            else
                mapChangeCount--;


            if (mapChangeCount == 1000)
            {               
                backGround1.DOColor(new Color(0, 0, 0, 0), 1f);
                backGround2.DOColor(new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f), 0.5f);
                isUp = false;
            }
            else if (mapChangeCount == 0)
            {
                backGround1.DOColor(new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f), 0.5f);
                backGround2.DOColor(new Color(0, 0, 0, 0), 1f);
                isUp = true;
            }
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

    public void MapSelect(string Name) // 맵 선택했을 때 
    {
        for (int i = 0; i < mapScipt.maps.Count; i++)
        {
            if (Name == mapScipt.maps[i].Name)
            {
                SceneManager.LoadScene("InGame");
            }
        }
    }


    public void MenuBtns()
    {
        Time.timeScale = 0;
        Options.SetActive(true);
        SoundManger.instance.BGM_POS(false);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        Options.SetActive(false);
        SoundManger.instance.BGM_POS(true);
    }

    public void GO_Stage()
    {
        SceneManager.LoadScene("StartScenes");
    }
    public void ReStartBtns() // 다시하기 버튼 누르면
    {
        StartCoroutine(ReStarts());
    }

    IEnumerator ReStarts()
    {
        Time.timeScale = 1;
        Jeon_Players.instance.animation.SetTrigger("Dead");
        while (!Jeon_Players.instance.animation.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
        {
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void EscBtns()
    {
        if (!Esc)
        {
            TouchFalseUI.SetActive(true);
            Esc = true;
            Time.timeScale = 0;

        }
        else
        {
            TouchFalseUI.SetActive(false);
            Esc = false;
            Time.timeScale = 1;

        }
    }
    public void FadeTouch()
    {
        if (CameraAI.instance.state == CameraAI.State.Go || CameraAI.instance.state == CameraAI.State.Return)
        {
            Fade.SetActive(false);
            CameraAI.instance.state = CameraAI.State.Start;
        }
    }


    public void Start_Loby()
    {
        StartCoroutine(Start_LobyUI());
    }

    IEnumerator Start_LobyUI()
    {
        Logo.DOColor(new Color(0, 0, 0, 0), 1f);
        while (Logo.color != new Color(0, 0, 0, 0))
        {
            yield return null;
        }
        Logo.gameObject.SetActive(false);

        Loby.DOColor(new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f), 1f);
        while (Loby.color != new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f))
        {
            yield return null;
        }
        LobyUI.SetActive(true);
    }

    public void Next_Btns()
    {
        StartCoroutine(Next_Stage());
    }

    public void Exit()
    {
        Application.Quit();
    }
    public IEnumerator Clear_Stars_Color()
    {
        for (int i = 0; i < mapScipt.maps.Count; i++)
        {
            if (mapScipt.maps[i].Name == Cun_Map)
            {
                mapScipt.maps[i].Stars.Clear();

                for (int k = 0; k < Stars.Count; k++)
                {
                    if (Stars[k].color == new Color(0, 0, 0, 0))
                    {
                        mapScipt.maps[i].Stars.Add(mapScipt.Non_Fill_Star);
                    }
                    else
                    {
                        mapScipt.maps[i].Stars.Add(mapScipt.Fill_Star);
                    }

                }
            }
        }

        for (int i = 0; i < Clear_Stars.Count; i++)
        {
            Clear_Stars[i].DOColor(Stars[i].color, 1f);
            while (Clear_Stars[i].color != Stars[i].color)
            {
                yield return null;
            }
        }



    }
    IEnumerator Next_Stage()
    {
        ClearUI.SetActive(false);
        Fade.SetActive(true);
        Image image = Fade.GetComponent<Image>();
        image.DOColor(Color.black, 1f);

        while (image.color != Color.black)
        {
            yield return null;
        }
        for (int i = 0; i < mapScipt.maps.Count; i++)
        {
            if (mapScipt.maps[i].Name == mapScipt.Save_Map_Name)
            {
                Cun_Map = mapScipt.maps[i + 1].Name;
                mapScipt.maps[i + 1].Lock = false;
            }
        }
        mapScipt.Save_Map_Name = Cun_Map;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        yield return null;
    }

    IEnumerator Start_Scene()
    {
        Fade.SetActive(true);
        Image image = Fade.GetComponent<Image>();
        image.DOColor(new Color(0, 0, 0, 0), 1f);
        SoundManger.instance.BGMplay("Map1");
        SoundManger.instance.BGM_POS(false);
        while (image.color != new Color(0, 0, 0, 0))
        {
            yield return null;
        }
        SoundManger.instance.BGM_POS(true);
        CameraAI.instance.Starts();
    }


    public void Loby_Go()
    {
        DOTween.Init(false, false, LogBehaviour.Default).SetCapacity(100, 20);
        SceneManager.LoadScene("StartScenes");
    }

}