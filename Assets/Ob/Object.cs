using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

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
    RaycastHit2D hit;
    public GameObject door;
    int count;
    string MapName;

    public void Start()
    {
        if (what == WhatOb.Stone)
            GameUI.instance.Stone.Add(this.gameObject.GetComponent<Rigidbody2D>());
    }

    public void Update()
    {
        if (what == WhatOb.Wind)
        {          /* 
            hit =  Physics2D.Raycast(transform.position, Vector2.left,5f);
            Debug.DrawRay(transform.position, Vector2.left * 5f, Color.red);
            if (hit.transform.gameObject == GameUI.instance.Player)
            {
                hit.transform.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 0));

            }
            else
            {
                return;
            }*/

        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (what == WhatOb.Button)
        {
            if (collision.gameObject.tag == "Line" && count == 0 || collision.gameObject.tag == "Player" && count == 0)
            {
                door.transform.position = new Vector2(door.transform.position.x, door.transform.position.y + 2);
                count++;
            }
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (what == WhatOb.Button)
        {
            if (collision.gameObject.tag == "Line" && count != 0 || collision.gameObject.tag == "Player" && count != 0)
            {
                door.transform.position = new Vector2(door.transform.position.x, door.transform.position.y - 2);
                count--;
            }

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && what == WhatOb.Thorn)
        {
            SoundManger.instance.SFXplay("Hit");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (collision.gameObject.tag == "Player" && what == WhatOb.Stone)
        {
            SoundManger.instance.SFXplay("Hit");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (collision.gameObject.tag == "Player" && what == WhatOb.Finsh)
        {
            GameUI.instance.ClearUI.SetActive(true);
            StartCoroutine(GameUI.instance.Clear_Stars_Color());
            SoundManger.instance.SFXplay("Clear");
            SoundManger.instance.BGM_POS(false);
            GameUI.instance.Cun_Map = MapName;

        }
    }
}
