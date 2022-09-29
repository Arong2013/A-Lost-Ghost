using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Object : MonoBehaviour
{
    public enum WhatOb
    {
        Thorn,
        Door,
    
    
    
    }

    [SerializeField]
    private WhatOb what;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (collision.CompareTag("Player") && what == WhatOb.Door)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
