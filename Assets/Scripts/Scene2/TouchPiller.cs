using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPiller : MonoBehaviour
{
    private Vector3 pillerPos;
    [HideInInspector]
    public bool isNear = true;
    public Transform gate;
    private AudioScript audioScript;
    private bool isPlay;
    private bool isPlay2;
    private void Start()
    {
        audioScript = FindObjectOfType<AudioScript>();
        pillerPos = transform.position;
        isNear = false;
    }
    private void Update()
    {
        
        if(pillerPos != transform.position)
        {
            if(transform.position.x >=58)
            {
                if(!isPlay)
                {
                    audioScript.SFXs[13].Play();
                    isPlay = true;
                    isPlay2 = false;
                }
                transform.position = new Vector3(58, transform.position.y, transform.position.z);
                gate.transform.position = Vector3.Lerp(gate.transform.position, new Vector3(gate.transform.position.x, 3.25f, gate.transform.position.z), 3f * Time.deltaTime);

            }
        }  
        if(!isNear)
        {
            if(!isPlay2 && isPlay)
            {
                audioScript.SFXs[13].Play();
                isPlay2 = true;
                isPlay = false;
            }
            transform.position = Vector3.Lerp(transform.position, new Vector3(57.75f, transform.position.y, transform.position.z), 3f* Time.deltaTime);
            gate.transform.position = Vector3.Lerp(gate.transform.position, new Vector3(gate.transform.position.x, 6.25f, gate.transform.position.z), 3f * Time.deltaTime);
        }
            
    }


}
