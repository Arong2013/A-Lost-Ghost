using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jang_Button : MonoBehaviour
{
    Rigidbody2D rigid;
    public GameObject door;
    public int count;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Line")
        {
            if(count == 0)
            {
                OpenDoor();   
                count++;
                Invoke("SetDoor", 10f);
            }
        }
    }

    void OpenDoor()
    {
        door.transform.position = new Vector2(door.transform.position.x, door.transform.position.y + 2);
    }
    
    void SetDoor()
    {
        door.transform.position = new Vector2(door.transform.position.x, door.transform.position.y - 2);
        count--;
    }
}
