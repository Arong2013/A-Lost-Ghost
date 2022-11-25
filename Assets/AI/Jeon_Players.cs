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
    public static Jeon_Players instance;
    #region Singleton
    void Awake()
    {
        instance = this;
       
    }
    #endregion

    Rigidbody2D rigidbody;
    PlayerDIs Playerdis;
    //BoxCollider2D boxcol;
    SpriteRenderer spriteren;
    [SerializeField]
    LayerMask Gorund;
    public Animator animation;
    public void Start()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        //boxcol = GetComponent<BoxCollider2D>();
        Playerdis = PlayerDIs.Normal;
        spriteren = GetComponent<SpriteRenderer>();
        animation = GetComponent<Animator>();
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
                animation.SetBool("Walk", true);
                break;
            case "Left":
                Playerdis = PlayerDIs.Left;
                spriteren.flipX = true;
                animation.SetBool("Walk", true);
                break;
           
        }
    }

    public void Jump()
    {
        RaycastHit2D JumpHit;

        JumpHit = Physics2D.Linecast(new Vector2(transform.position.x, transform.position.y - 1.2f), new Vector2(transform.position.x, transform.position.y - 1.2f), Gorund);
        if (JumpHit)
        {
            SoundManger.instance.SFXplay("Jump");
            Playerdis = PlayerDIs.Jump;
        }
        else
        {
            Playerdis = PlayerDIs.Normal;
        }
    }
    public void ButtonUP()
    {
        Playerdis = PlayerDIs.Normal;
        animation.SetBool("Walk", false);
    }
}