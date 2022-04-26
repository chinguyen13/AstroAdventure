using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class AudioScript : MonoBehaviour
{
    public int activeNum = 0;
    public AudioSource[] backgroundMusic;
    [HideInInspector]
    public bool isPlay;
    [HideInInspector]
    public bool isReduce;
    public AudioSource[] SFXs;

    //public GameObject volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(activeNum == 1)
        {
            if (backgroundMusic[0].volume != 0)
                backgroundMusic[0].volume -= 0.2f * Time.deltaTime;
            else if(!isPlay)
            {
                StartCoroutine(PlaySceneText());                          
            }
            if(isReduce)
            {
                if (backgroundMusic[1].volume != 0)
                    backgroundMusic[1].volume -= 0.2f * Time.deltaTime;
                else
                {
                    activeNum++;
                    isPlay = false;
                }
            }
        }else if(activeNum ==2)
        {
            if(!isPlay)
            {
                backgroundMusic[2].Play();
                isPlay = true;
            }
        }else if(activeNum >=3 && activeNum <6)
        {
            if (backgroundMusic[activeNum-1].volume != 0)
                backgroundMusic[activeNum-1].volume -= 0.2f * Time.deltaTime;
            else if(!isPlay)
            {
                backgroundMusic[activeNum].Play();
                isPlay = true;
            }
        }else if(activeNum >=6)
        {
            if (backgroundMusic[5].volume != 0)
                backgroundMusic[5].volume -= 0.2f * Time.deltaTime;
        }

    }

    IEnumerator PlaySceneText()
    {
        SFXs[0].Stop();
        backgroundMusic[1].Play();
        isPlay = true;
        yield return new WaitForSeconds(45.5f);
        isReduce = true;
    }

}
