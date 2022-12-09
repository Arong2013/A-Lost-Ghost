using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    public void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 0));           
        }
    }
}
