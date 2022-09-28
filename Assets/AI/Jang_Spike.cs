using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jang_Spike : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteren;
    BoxCollider2D boxcol;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteren = GetComponent<SpriteRenderer>();
        boxcol = GetComponent<BoxCollider2D>();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Spike")
        {
            spriteren.color = new Color(1, 1, 1, 0.4f);
            spriteren.flipY = true;

            boxcol.enabled = false;
            Invoke("Restart", 1);
        }
        
    }

    void Restart()
    {
        spriteren.color = new Color(1, 1, 1, 1f);
        spriteren.flipY = false;

        boxcol.enabled = true;
        rigid.transform.position = new Vector3(0, 0, -1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
