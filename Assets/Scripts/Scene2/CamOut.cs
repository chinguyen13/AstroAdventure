using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamOut : MonoBehaviour
{
    private bool isTriggered;
    private bool isStop;
    private bool isExit;
    public float speed;
    private float curTime;
    public Transform focus;
    private Transform player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isTriggered = true;
            curTime = 0;
            player = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isTriggered = false;
            isExit = true;
            curTime = 0;
        }
    }

    private void Update()
    {
        if(isTriggered && !isStop)
        {
            curTime += Time.deltaTime;
            Camera.main.GetComponent<CameraFollow>().offset = new Vector3(0, 1, -15 - curTime* speed);
            Camera.main.GetComponent<CameraFollow>().smoothFactor = 0.5f;
            Camera.main.GetComponent<CameraFollow>().player = focus;
            if (Camera.main.GetComponent<CameraFollow>().offset.z <=-20)
            {
                isStop = true;
            }
        }
        if(isExit)
        {
            curTime += Time.deltaTime;
            Camera.main.GetComponent<CameraFollow>().offset = new Vector3(0, 1, -20 + curTime * (speed*1.5f));
            Camera.main.GetComponent<CameraFollow>().smoothFactor = 2;
            Camera.main.GetComponent<CameraFollow>().player = player;
            if (Camera.main.GetComponent<CameraFollow>().offset.z >= -15)
            {
                Camera.main.GetComponent<CameraFollow>().offset.z = -15;
                Camera.main.GetComponent<CameraFollow>().smoothFactor = 4;
                Destroy(this.gameObject, 2f);
            }
        }
    }
}
