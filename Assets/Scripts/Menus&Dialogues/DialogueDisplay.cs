using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueDisplay : MonoBehaviour
{
    [SerializeField] private TextWriter textWriter;
    public string TextDisplay;
    public TextMeshProUGUI textTMPro;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" )
        {
            textTMPro.transform.parent.gameObject.SetActive(true);
            StartCoroutine(displayingText());           
        }
    }


    IEnumerator displayingText()
    {
        yield return new WaitForSeconds(0.1f);
        textWriter.AddWriter(textTMPro, TextDisplay, 0.05f, true);
        Destroy(gameObject);
        
    }

}
