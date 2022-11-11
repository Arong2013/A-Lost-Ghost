using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CameraAI : MonoBehaviour
{
    public static CameraAI instance;
    #region Singleton



    void Awake()
    {
        instance = this;       
    }
    #endregion
    public enum State
    {
        Start,
        Go,
        Return,
    }
    public GameObject Player;
    GameObject Finsh;
    public State state;
    Transform AT;

    public void Start()
    {
        state = State.Start;
        AT = Player.transform;
        this.gameObject.transform.position = new Vector3(Player.transform.position.x,-6, -10);
    }
    public void Starts()
    {     
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
        {
            this.gameObject.transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y, -10);
            if(Player.transform.position.y<-3)
                this.gameObject.transform.position = new Vector3(Player.transform.position.x, -2, -10);
        }
            
        else if(state == State.Go)
        {
            Vector3 vector3 = new Vector3(Finsh.transform.position.x, Finsh.transform.position.y, Finsh.transform.position.z - 10);
            transform.position = Vector3.MoveTowards(transform.position, vector3, Time.deltaTime * 18f);
            if (transform.position == vector3)
            {               
                state = State.Return;             
            }
        }
        else if(state == State.Return)
        {
            Vector3 vector3 = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - 10);
            transform.position = Vector3.MoveTowards(transform.position, vector3, Time.deltaTime * 18f);

            if (transform.position == vector3)
            {
                transform.position = new Vector3(AT.position.x, AT.position.y, -10);
                for(int i =0; i<GameUI.instance.Stone.Count; i++)
                {
                   
                    GameUI.instance.Stone[i].bodyType = RigidbodyType2D.Dynamic;
                }
                AT = null;
                
                state = State.Start;
                GameUI.instance.Fade.SetActive(false);
            }
        }
    }



}
