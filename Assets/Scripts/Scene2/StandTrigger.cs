using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandTrigger : MonoBehaviour
{
    GameObject piller;
    private void Start()
    {
        piller = transform.parent.gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" || collision.tag == "Pushable")
            piller.GetComponent<TouchPiller>().isNear = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Pushable")
            piller.GetComponent<TouchPiller>().isNear = false;
    }

}
