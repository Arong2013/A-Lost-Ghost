using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerDIs
{
    Right,
    Left,
    Jump,
    Normal
}



public class Jeon_Players : MonoBehaviour
{
    Rigidbody2D rigidbody;
    PlayerDIs Playerdis;
    //BoxCollider2D boxcol;
    SpriteRenderer spriteren;
    public LayerMask Gorund;
    public GameUI gameui;

    public void Start()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        //boxcol = GetComponent<BoxCollider2D>();
        Playerdis = PlayerDIs.Normal; 
        spriteren = GetComponent<SpriteRenderer>();
    }
    public void FixedUpdate()
    {
        switch (Playerdis)
        {
            case PlayerDIs.Normal:
                //rigidbody.AddForce(new Vector2(0,0));
                break;
            case PlayerDIs.Right:
                transform.Translate(new Vector3(1 * 5f * Time.deltaTime, 0, 0));
                break;
            case PlayerDIs.Left:
                transform.Translate(new Vector3(-1 * 5f * Time.deltaTime, 0, 0));
                break;
            case PlayerDIs.Jump:
                rigidbody.AddForce(Vector2.up * 1f, ForceMode2D.Impulse);
                Playerdis = PlayerDIs.Normal;
                break;
        }
    }

   
    public void ButtonDown(string Dis)
    {
        switch (Dis)
        {
            case "Normal":
                Playerdis = PlayerDIs.Normal;
                break;
            case "Right":
                Playerdis = PlayerDIs.Right;
                spriteren.flipX = false;
                break;
            case "Left":
                Playerdis = PlayerDIs.Left;
                spriteren.flipX = true;
                break;
            case "Jump":                
                RaycastHit2D JumpHit;
                JumpHit = Physics2D.Linecast(new Vector2(transform.position.x, transform.position.y - 0.5f), new Vector2(transform.position.x, transform.position.y - 1f), Gorund);
                if(JumpHit)
                {
                    Playerdis = PlayerDIs.Jump;
                }
                else
                {
                    Playerdis = PlayerDIs.Normal;
                }
                break;

        }
    }
    public void ButtonUP()
    {
        Playerdis = PlayerDIs.Normal;
    }

    private void OnParticleCollision(GameObject other)
    {
        GameUI.instance.Player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 0));
       
    }
}
