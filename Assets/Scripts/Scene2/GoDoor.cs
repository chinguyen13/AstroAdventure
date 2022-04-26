using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDoor : MonoBehaviour
{
    public GameObject transition;
    private bool isTriggered;
    private Transform player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player = collision.transform;
            isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isTriggered = false;
        }
    }

    private void Update()
    {
        if(isTriggered)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Teleport());
            }
        }
    }

    IEnumerator Teleport()
    {
        transition.SetActive(true);
        yield return new WaitForSeconds(1f);
        player.position = new Vector3(-22, -3, 0);
        Camera.main.transform.position = player.position;
        Camera.main.GetComponent<CameraFollow>().bottomLimit = -6;
    }
}
