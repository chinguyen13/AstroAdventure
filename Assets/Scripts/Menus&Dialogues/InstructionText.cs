using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionText : MonoBehaviour
{
    public GameObject Dialogue;
    public Sprite image;
    public Image imageSocket;
    public bool isLoop;
    // Start is called before the first frame update
    void Start()
    {
        Dialogue.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            imageSocket.sprite = image;
            Dialogue.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        Dialogue.GetComponent<Animator>().SetBool("IsExit", true);
        yield return new WaitForSeconds(1f);
        if(isLoop)
        {
            Dialogue.SetActive(false);
        }else
            Destroy(this,2f);
    }
}
