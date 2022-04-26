using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAndNumbers : MonoBehaviour
{
    private bool isTrigger;
    public GameObject slot;
    public Sprite[] numbers;
    private int curNum =0;
    private CheckNumbers checknum;
    public bool isNum2;
    private AudioScript audioScript;
    private void Start()
    {
        audioScript = FindObjectOfType<AudioScript>();
        checknum = FindObjectOfType<CheckNumbers>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            isTrigger = true;
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
                audioScript.SFXs[17].Play();
                curNum++;
                if(!isNum2)
                    checknum.num1 = curNum;
                else
                    checknum.num2 = curNum;
                if (curNum < 10)
                    slot.GetComponent<SpriteRenderer>().sprite = numbers[curNum];
                else
                {
                    curNum = 0;
                    slot.GetComponent<SpriteRenderer>().sprite = numbers[curNum];
                }
            }
        }
    }
}
