using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornGrow : MonoBehaviour
{
    public List<Transform> Group1;

    public List<Transform> Group2;

    public float timeCount;
    public float speed = 2f;
    public AudioSource audioSource;
    private bool isPlay;


    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;

        if(timeCount >= 1.8f)
        {
            if (!isPlay)
            {
                audioSource.Play();
                isPlay = true;
            }
            foreach (Transform obj in Group1)
            {
                obj.localScale = Vector3.Lerp(obj.localScale, new Vector3(obj.localScale.x, -0.2f, obj.localScale.z), speed * Time.deltaTime);
            }
            foreach (Transform obj in Group2)
            {
                obj.localScale = Vector3.Lerp(obj.localScale, new Vector3(obj.localScale.x, 2.4f, obj.localScale.z), speed * Time.deltaTime);
            }
        }
        if(timeCount < 1.8f)
        {
            
            foreach (Transform obj in Group1)
            {
                obj.localScale = Vector3.Lerp(obj.localScale, new Vector3(obj.localScale.x, 2.4f, obj.localScale.z), speed * Time.deltaTime);
            }
            foreach (Transform obj in Group2)
            {
                obj.localScale = Vector3.Lerp(obj.localScale, new Vector3(obj.localScale.x, -0.2f, obj.localScale.z), speed * Time.deltaTime);
            }
        }
        if(timeCount >=3.6f)
        {
            audioSource.Play();
            isPlay = false;
            timeCount = 0;
        }
    }
}
