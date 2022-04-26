using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamLimit : MonoBehaviour
{
    public float bottom;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Camera.main.GetComponent<CameraFollow>().bottomLimit = bottom;
        }
    }
}
