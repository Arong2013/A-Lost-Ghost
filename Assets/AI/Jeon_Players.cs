using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public LayerMask Gorund;

    public void Start()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        Playerdis = PlayerDIs.Normal;
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
                break;
            case "Left":
                Playerdis = PlayerDIs.Left;
                break;
            case "Jump":                
                RaycastHit2D JumpHit;
                JumpHit = Physics2D.Linecast(new Vector2(transform.position.x, transform.position.y - 1f), new Vector2(transform.position.x, transform.position.y - 1f), Gorund);
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

}
