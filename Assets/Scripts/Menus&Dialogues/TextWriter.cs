using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextWriter : MonoBehaviour
{
    private TextMeshProUGUI textTMPro;
    private string textToWrite;
    private int characterIndex;
    private float timePerChar;
    private float timer;
    private bool invisibleCharacters;
    private bool isCompleted;

    public void AddWriter(TextMeshProUGUI textTMPro, string textToWrite, float timePerChar, bool invisibleCharacters)
    {
        this.textTMPro = textTMPro;
        this.textToWrite = textToWrite;
        this.timePerChar = timePerChar;
        this.invisibleCharacters = invisibleCharacters;
        characterIndex = 0;
    }

    private void Update()
    {
        if (textTMPro != null && !isCompleted)
        {
            timer -= Time.deltaTime;
            while (timer <= 0f)
            {

                timer += timePerChar;
                characterIndex++;
                string text = textToWrite.Substring(0, characterIndex);
                if(invisibleCharacters)
                {
                    text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                }

                textTMPro.text = text;

                if (characterIndex >= textToWrite.Length)
                {
                    timer = 2;
                    isCompleted = true;
                    return;
                }
            }
        }
        else if (textTMPro != null && isCompleted)
        {
            timer -= Time.deltaTime;
            if(timer <=0f)
            {
                textTMPro.color = new Color(textTMPro.color.r, textTMPro.color.g, textTMPro.color.b, textTMPro.color.a - 0.01f);
                if (textTMPro.color.a <= 0)
                {
                    textTMPro.text = string.Empty;
                    textTMPro.color = new Color(textTMPro.color.r, textTMPro.color.g, textTMPro.color.b, 1);
                    textTMPro.transform.parent.gameObject.SetActive(false);
                    isCompleted = false;
                    textTMPro = null;
                    return;
                }
            }
               
        }    
    }



}
