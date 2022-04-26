using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAndGates : MonoBehaviour
{
    private bool isTriggered;
    public Transform lever;
    public Transform[] gates;
    private bool isSwap;
    private bool isTouch;
    private AudioScript audioScript;

    private void Start()
    {
        audioScript = FindObjectOfType<AudioScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
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
        if (isTriggered)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isTouch = true;
                isSwap = !isSwap;
                foreach(Transform gate in gates)
                {
                    gate.GetComponent<Piller>().isBlock = !gate.GetComponent<Piller>().isBlock;
                }
                    audioScript.SFXs[13].Play();

            }
        }
            if(isTouch)
            {
                if (isSwap)
                {
                    lever.rotation = Quaternion.Slerp(lever.rotation, Quaternion.Euler(Vector3.forward * -25f), 4f * Time.deltaTime);               
                }
                else
                {
                    lever.rotation = Quaternion.Slerp(lever.rotation, Quaternion.Euler(Vector3.forward * 25f), 4f * Time.deltaTime);
                }
            }
    }


}
