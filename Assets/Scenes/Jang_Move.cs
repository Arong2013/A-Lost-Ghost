using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jang_Move : MonoBehaviour
{
    Rigidbody2D rigid;
    public float maxSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (rigid.velocity.x > maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
    }

    public void Go()
    {
        rigid.AddForce(Vector2.right * 5, ForceMode2D.Impulse);
        Invoke("Go", 0.2f);
    }

    public void Stop()
    {
        CancelInvoke("Go");
    }
}
