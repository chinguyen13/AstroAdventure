using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndTrigger : MonoBehaviour
{
    public GameObject blackScreen;
    private AudioScript audioScript;
    private bool isIncrease;
    public bool isChangeMusic;
    private void Start()
    {
        audioScript = FindObjectOfType<AudioScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(isChangeMusic)
            {
                if (!isIncrease)
                    audioScript.activeNum++;
                isIncrease = true;
                audioScript.isPlay = false;
            }   
            blackScreen.SetActive(true);
            StartCoroutine(SceneChange());
        }    
    }

    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
