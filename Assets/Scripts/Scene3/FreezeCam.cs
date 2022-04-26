using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeCam : MonoBehaviour
{
    private bool isTriggered;
    private bool isStop;
    private bool isOut;
    private Transform player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isTriggered = true;
            player = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isOut = true;
            isTriggered = false;
        }
    }

    private void Update()
    {
        if(isTriggered && !isStop)
        {
            Camera.main.GetComponent<CameraFollow>().smoothFactor = 1;
            Camera.main.GetComponent<CameraFollow>().player = this.transform;
            isStop = true;
        }
        if(isOut)
        {
            Camera.main.GetComponent<CameraFollow>().smoothFactor = 4;
            Camera.main.GetComponent<CameraFollow>().player = player;
            Destroy(this.gameObject);
        }
    }
}
