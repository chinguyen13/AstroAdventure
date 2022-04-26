using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Transform[] allTrigger;
    public GameObject[] dusts;
    public int[] corrects;
    public int[] symbols;
    public bool isEnough;
    private bool isSort;
    public bool isCorrect;
    public bool isRetry;
    private float curTime;
    private AudioScript audioScript;
    private bool isPlay;
    private bool isPlay2;
    void Start()
    {
        curTime = 0;
        audioScript = FindObjectOfType<AudioScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnough)
        { 
            for (int i = 0; i < symbols.Length; i++)
            {
                if (symbols[i] == 0)
                {
                    isEnough = false;
                    break;
                }
                isEnough = true;
            }
        }
        if(isEnough)
        {
            if(!isSort)
            {
                for (int i = 1; i < symbols.Length; i++)
                {
                    if (symbols[i] < symbols[i - 1])
                    {
                        var a = symbols[i - 1];
                        symbols[i - 1] = symbols[i];
                        symbols[i] = a;
                    }
                }
                isSort = true;
            }else
            {
                for(int i =0;i<symbols.Length;i++)
                {
                    if (symbols[i] != corrects[i])
                    {
                        isCorrect = false;
                        break;
                    }
                        isCorrect = true;
                }

                if(!isCorrect)
                {
                    foreach(GameObject dust in dusts)
                    {
                        dust.SetActive(true);                       
                    }
                    StartCoroutine(CamShakeHere());
                    for(int i = 0;i<symbols.Length;i++)
                    {
                        symbols[i] = 0;
                    }
                    isRetry = true;
                    isEnough = false;
                    isSort = false;
                    if(!isPlay2)
                    {
                        audioScript.SFXs[16].Play();
                        isPlay2 = true;
                    }

                }
                else
                {
                    if(!isPlay)
                    {
                        audioScript.SFXs[10].Play();
                        isPlay = true;
                    }
                    transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(transform.localPosition.x, 1f, transform.localPosition.z), 2 * Time.deltaTime);
                }
            }

            
        }
        if(isRetry)
        {
            curTime += Time.deltaTime;
            foreach (Transform trigger in allTrigger)
            {
                if(trigger.localPosition.y != -4.15f)
                {
                    trigger.localPosition = Vector3.Lerp(trigger.localPosition, new Vector3(trigger.localPosition.x, -4.15f, trigger.localPosition.z), 2 * Time.fixedDeltaTime);
                }               
            }
            if (curTime >= 2f)
            {
                foreach (Transform trigger in allTrigger)
                {
                    trigger.GetComponent<SymbolTrigger>().isCollect = false;
                    trigger.GetComponent<SymbolTrigger>().isPress = false;
                }
                curTime = 0;
                isPlay2 = false;
                isRetry = false;
            }

        }
    }

    IEnumerator CamShakeHere()
    {
        yield return new WaitForSeconds(2f);
        foreach (GameObject dust in dusts)
        {
            dust.SetActive(false);
        }
    }
}
