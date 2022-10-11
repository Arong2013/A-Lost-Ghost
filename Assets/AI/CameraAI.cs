using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CameraAI : MonoBehaviour
{
    public enum State
    {
        Start,
        Go,
        Return,
    }
    public GameObject Player;
    GameObject Finsh;
    State state;
    Transform AT;

    private void Start()
    {
        state = State.Start;
        AT = Player.transform;
        StartCoroutine(CameraAI_Start());
    }
    
    IEnumerator CameraAI_Start()
    {
        yield return new WaitForSeconds(1f);
        Finsh = GameObject.Find("Finsh");
        state = State.Go;
       
    }

    private void Update()
    {
        if (state == State.Start)
            transform.position = new Vector3(AT.position.x, AT.position.y, transform.position.z);
        else if(state == State.Go)
        {
            Vector3 vector3 = new Vector3(Finsh.transform.position.x, Finsh.transform.position.y, Finsh.transform.position.z - 10);
            transform.position = Vector3.MoveTowards(transform.position, vector3, Time.deltaTime * 10f);
            if (transform.position == vector3)
            {               
                state = State.Return;             
            }
        }
        else if(state == State.Return)
        {
            Vector3 vector3 = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - 10);
            transform.position = Vector3.MoveTowards(transform.position, vector3, Time.deltaTime * 10f);

            if (transform.position == vector3)
            {
                transform.position = new Vector3(AT.position.x, AT.position.y, -10);
                state = State.Start;
                for(int i = 0; i<GameUI.instance.Stone_OB.Count; i++)
                {
                    GameUI.instance.Stone_OB[i].bodyType = RigidbodyType2D.Dynamic;
                }
            }
        }
    }



}
