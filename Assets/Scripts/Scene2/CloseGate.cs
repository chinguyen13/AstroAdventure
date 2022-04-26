using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGate : MonoBehaviour
{
    public GameObject gate;
    private Vector3 originalPos;
    private bool isTriggered;
    private Camera cam;
    private void Start()
    {
        originalPos = gate.transform.position;
        cam = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isTriggered = true;
        }
    }

    private void Update()
    {
        if(isTriggered)
        {
            gate.transform.position = Vector3.Lerp(gate.transform.position, new Vector3(gate.transform.position.x, originalPos.y, gate.transform.position.z), 3f * Time.deltaTime);
            StartCoroutine(triggered());
        }
    }

    IEnumerator triggered()
    {
        yield return null;
    }
}
