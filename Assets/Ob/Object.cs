using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Object : MonoBehaviour
{
    public enum WhatOb
    {
        Thorn,
        Wind   
    }

    [SerializeField]
    private WhatOb what;
    RaycastHit2D hit;
  
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

    
}
