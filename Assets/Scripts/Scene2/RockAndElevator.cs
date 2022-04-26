using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAndElevator : MonoBehaviour
{
    public bool isReach;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Pushable")
        {
            isReach = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Pushable")
        {
            isReach = false;
        }
    }
}
