using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class CheckNumbers : MonoBehaviour
{
    [HideInInspector]
    public int num1;
    [HideInInspector]
    public int num2;

    public int correctNum1;
    public int correctNum2;
    public GameObject dust;
    public Light2D _light;
    private float curTime;
    public Transform thorn1;
    public Transform thorn2;
    private AudioScript audioScript;
    private bool isPlay;
    private bool isPlay2;
    void Start()
    {
        audioScript = FindObjectOfType<AudioScript>();
    }
    // Update is called once per frame
    void Update()
    {
        if(num1 == correctNum1 && num2 == correctNum2)
        {
            if(!isPlay)
            {
                audioScript.SFXs[10].Play();
                isPlay = true;
            }

            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(-97, transform.localPosition.y, transform.localPosition.z), 1f * Time.deltaTime);
            
            if(transform.localPosition.x >= -100f)
            {
                curTime += Time.deltaTime;

                if (curTime < 5)
                {
                    _light.pointLightInnerRadius = curTime * 6;
                    _light.pointLightOuterRadius = curTime * 6 + 10;
                }
                if (curTime >= 4)
                {
                    if(!isPlay2)
                    {
                        audioScript.SFXs[18].Play();
                        isPlay2 = true;
                    }
                    thorn1.localPosition = Vector3.Lerp(thorn1.localPosition, new Vector3(thorn1.localPosition.x, -5, thorn1.localPosition.z), 1.5f * Time.deltaTime);
                    thorn2.localPosition = Vector3.Lerp(thorn2.localPosition, new Vector3(thorn2.localPosition.x, -1, thorn2.localPosition.z), 1.5f * Time.deltaTime);
                }
            }
            if (transform.localPosition.x <= -97.2f)
            {
                dust.SetActive(true);
            }else
            {
                dust.SetActive(false);
            }
        }
    }
}
