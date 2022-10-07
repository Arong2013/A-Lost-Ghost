using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Object : MonoBehaviour
{
    public enum WhatOb
    {
        Thorn,
        Wind,
        Button
    }

    [SerializeField]
    private WhatOb what;
    RaycastHit2D hit;
    public GameObject door;
    int count;

    public void Update()
    {
        if(what == WhatOb.Wind)
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && what == WhatOb.Thorn)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(what == WhatOb.Button)
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
        if(what == WhatOb.Button)
        {
            if (collision.gameObject.tag == "Line" && count != 0 || collision.gameObject.tag == "Player" && count != 0)
            {
                door.transform.position = new Vector2(door.transform.position.x, door.transform.position.y - 2);
                count--;
            }

        }

    }
}
