using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Object : MonoBehaviour
{
    public enum WhatOb
    {
        Thorn,
        Wind,
        Button,
        Finsh,
        Stone
    }

    [SerializeField]
    private WhatOb what;
    [FoldoutGroup("Button")]
    [SerializeField]
    GameObject Doors;
    [FoldoutGroup("Button")]
    [SerializeField]
    List<Sprite> btns;
    [FoldoutGroup("Stone")]
    [SerializeField]
    BoxCollider2D Moves;



    RaycastHit2D hit;
    string MapName;

    public void Start()
    {
        if (what == WhatOb.Stone)
            GameUI.instance.Stone.Add(this.gameObject.GetComponent<Rigidbody2D>());
    }

    private void OnCollisionExit2D(Collision2D collision)
    {/*
        if (what == WhatOb.Button)
        {
            if (collision.gameObject.tag == "Line" || collision.gameObject.tag == "Player")
            {
                if (Doors.GetComponent<Rigidbody2D>().velocity.magnitude == 0)
                    Doors.transform.DOMoveY(0, 1f);

                this.gameObject.GetComponent<SpriteRenderer>().sprite = btns[1];
            }

        }*/

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && what == WhatOb.Thorn)
        {
            SoundManger.instance.SFXplay("Hit");
            StartCoroutine(ReStarts());
        }
        else if (collision.gameObject.tag == "Player" && what == WhatOb.Stone)
        {
            SoundManger.instance.SFXplay("Hit");
            StartCoroutine(ReStarts());
        }
        else if (collision.gameObject.tag == "Player" && what == WhatOb.Finsh)
        {
            GameUI.instance.ClearUI.SetActive(true);
            StartCoroutine(GameUI.instance.Clear_Stars_Color());
            SoundManger.instance.SFXplay("Clear");
            SoundManger.instance.BGM_POS(false);
            GameUI.instance.Cun_Map = MapName;

        }
        else if (what == WhatOb.Button && collision.gameObject.tag == "Line")
        {
            Doors.transform.DOLocalMoveY(Doors.transform.position.y+6, 1f);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = btns[0];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && what == WhatOb.Stone)
        {
            this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }

        if (collision.gameObject.tag == "Player" && what == WhatOb.Thorn)
        {
            SoundManger.instance.SFXplay("Hit");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator ReStarts()
    {
        Time.timeScale = 1;
        Jeon_Players.instance.animation.SetTrigger("Hit");
        while (!Jeon_Players.instance.animation.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
        {
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
