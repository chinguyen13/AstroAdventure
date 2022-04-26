using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDoor3 : MonoBehaviour
{
    private bool isTrigger;
    public GameObject transition;
    private Transform player;
    private AudioScript audioScript;

    private void Start()
    {
        audioScript = FindObjectOfType<AudioScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isTrigger = true;
            player = collision.transform;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            isTrigger = false;
    }

    private void Update()
    {
        if (isTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Teleport());
            }
        }
    }

    IEnumerator Teleport()
    {
        transition.SetActive(true);
        yield return new WaitForSeconds(1f);
        player.position = new Vector3(-2.5f, -2.75f, 0);
        Camera.main.transform.position = player.position;
        Camera.main.GetComponent<CameraFollow>().bottomLimit = -1.5f;
        Camera.main.GetComponent<CameraFollow>().offset.y = -1f;
        audioScript.activeNum++;
        audioScript.isPlay = false;
        yield return new WaitForSeconds(1f);
        transition.SetActive(false);
    }
}
