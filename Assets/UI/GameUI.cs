using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class Maps
{
    public string Name;
    public GameObject Map;
}

public class GameUI : MonoBehaviour
{
    enum WhatScean
    {
        Stage,
        Lobby
    }
     [SerializeField]
    WhatScean whatScean;
    public static GameUI instance;
    #region Singleton



    void Awake()
    {
        instance = this;
        this.gameObject.GetComponent<GameUI>().enabled = true;
        if (whatScean == WhatScean.Stage) // ����������� �� ���� 
        {
            for (int i = 0; i < maps.Count; i++)
            {
                if (maps[i].Name == Map_Name)
                    Instantiate(maps[i].Map);
            }

            GameObject Finsh = GameObject.Find("Finsh");

        }
        
        if(whatScean == WhatScean.Lobby)
        if (MapSlot != null) // �� ������ ���ٸ� ���� ���� ��ŭ ���� ���� = �� ����ȭ�鿡�� �������� ���̱� ���� 
            for (int i = 0; i < maps.Count; i++)
            {
                Instantiate(MapSlot, MapParent.transform);
            }

        if (MapParent != null)
        {
            for (int i = 0; i < MapParent.transform.childCount; i++)
            {
                mapSlots.Add(MapParent.transform.GetChild(i).GetComponent<MapSlot>());
                MapParent.transform.GetChild(i).GetComponent<MapSlot>().map = maps[i];
            }
        }
    }
    #endregion

    public GameObject This_Game_OB;
    public GameObject TouchUI, DrawBtns, TouchFalseUI, Player, MapParent, MapSlot;
    public Slider slider;
    public List<Rigidbody2D> Stone_OB;

   
    public int SliderV; // �� �׸��� ��
    public string Map_Name; // ���� �� �̸� 

    bool Esc;


    [SerializeField]
    public List<Maps> maps;

    [SerializeField]
    List<MapSlot> mapSlots;

    public GameObject MapSelectUI;

    public void Start()
    {


        SliderV = 1000; //  �׸��� ���� �������� �� 
    }

    void OnCollisionEnter2D(Collision2D collision) // jang_ �߰� ���������� �ǵ�����
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.position = new Vector3(0, 0, -1);
        }

    }
    public void DrawBtns_Down() // �׸���
    {
        TouchUI.SetActive(true);
        if (Jeon_Draw.instance.what == Jeon_Draw.What.Draw)
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
        if (slider != null)
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

    public void MapSelect(string Name) // �� �������� �� 
    {
        for (int i = 0; i < maps.Count; i++)
        {
            if (Name == maps[i].Name)
            {
                SceneManager.LoadScene("InGame");
            }
        }
    }


    public void MenuBtns()
    {

    }
    public void ReStartBtns() // �ٽ��ϱ� ��ư ������
    {
        Time.timeScale = 1;
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

}