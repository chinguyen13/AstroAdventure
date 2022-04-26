using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private bool isTrigger;
    public GameObject endCanvas;
    private AudioScript audioScript;

    void Start()
    {
        audioScript = FindObjectOfType<AudioScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Player")
        {
            isTrigger = true;
            collision.GetComponent<PlayerController>().enabled = false;
            audioScript.SFXs[2].Stop();
        }

    }

    private void Update()
    {
        if(isTrigger)
        {
            StartCoroutine(endGame());
        }
    }

    IEnumerator endGame()
    {
        endCanvas.SetActive(true);
        yield return new WaitForSeconds(20f);
        audioScript.GetComponent<AudioScript>().activeNum++;
        yield return new WaitForSeconds(2f);
        Destroy(audioScript.gameObject);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene(0);
    }
}
