using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoElevator : MonoBehaviour
{
    public float smallLimit;
    public float bigLimit;
    public bool isHorizontal;
    private bool isReturn;
    public Transform player;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (player.GetComponent<PlayerController>().moveInput == 0)
        {
            if (isHorizontal)
            {
                if (!isReturn)
                    player.Translate(Vector3.left * 3f * Time.deltaTime, Space.Self);
                else
                    player.Translate(Vector3.right * 3f * Time.deltaTime, Space.Self);
            }
        }    
        
            
    }
    // Update is called once per frame
    void Update()
    {
        if (!isHorizontal)
        {
            if(!isReturn)
            {
                transform.Translate(Vector3.down * 3f * Time.deltaTime, Space.Self);
                if (transform.position.y <= smallLimit)
                    isReturn = true;
            }
            else
            {
                transform.Translate(Vector3.up * 3f * Time.deltaTime, Space.Self);
                if (transform.position.y >= bigLimit)
                    isReturn = false;
            }

        }
        else
        {
            if (!isReturn)
            {
                transform.Translate(Vector3.left * 3f * Time.deltaTime, Space.Self);
                if (transform.position.x <= smallLimit)
                    isReturn = true;
            }
            else
            {
                transform.Translate(Vector3.right * 3f * Time.deltaTime, Space.Self);
                if (transform.position.x >= bigLimit)
                    isReturn = false;
            }
        }
    }
}
