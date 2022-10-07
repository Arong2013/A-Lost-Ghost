using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAI : MonoBehaviour
{
    public GameObject Player;
    Transform AT;

    private void Start()
    {
        AT = Player.transform;
    }

    private void Update()
    {
        transform.position = new Vector3(AT.position.x, AT.position.y, transform.position.z);
    }

}
