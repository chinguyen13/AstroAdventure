using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolTrigger : MonoBehaviour
{
    public int symbolNum;
    public bool isCollect;
    private OpenDoor open;
    private bool isTrigger;
    public bool isPress;
    private AudioScript audioScript;
    private void Start()
    {
        open = FindObjectOfType<OpenDoor>();
        audioScript = FindObjectOfType<AudioScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isTrigger = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            isTrigger = false;
    }

    private void Update()
    {
        if(isTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(!open.isEnough)
                    isPress = true;
                audioScript.SFXs[15].Play();
            }
        }
        if (isPress)
        {
            if (!isCollect)
            {
                for (int i = 0; i < open.symbols.Length; i++)
                {
                    if (open.symbols[i] == 0)
                    {
                        open.symbols[i] = symbolNum;
                        break;
                    }
                }
                isCollect = true;
            }
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(transform.localPosition.x, -4.65f, transform.localPosition.z), 2 * Time.deltaTime);
        }
 
    }
}
