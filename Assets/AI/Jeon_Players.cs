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

    public void Start()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        Playerdis = PlayerDIs.Normal;
    }
    public void Update()
    {
        switch (Playerdis)
        {
            case PlayerDIs.Normal:
                rigidbody.AddForce(new Vector2(0, 0));
                break;
            case PlayerDIs.Right:
                rigidbody.AddForce(new Vector2(1, 0));
                break;
            case PlayerDIs.Left:
                rigidbody.AddForce(new Vector2(-1, 0));
                break;
            case PlayerDIs.Jump:
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
                Playerdis = PlayerDIs.Jump;
                break;

        }
    }
    public void ButtonUP()
    {
        Playerdis = PlayerDIs.Normal;
    }

}
