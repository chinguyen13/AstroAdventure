using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTrigger : MonoBehaviour
{
    private Color32 blue;
    private Color32 darkBlue;
    private Color32 normal;
    private AudioScript audioScript;
    // Start is called before the first frame update
    void Start()
    {
        audioScript = FindObjectOfType<AudioScript>();
        blue = new Color32(29, 196, 226, 230);
        darkBlue = new Color32(0, 73, 86, 230);
        normal = new Color32(0, 0, 0, 230);
    }

    public void PointerEnter()
    {
        gameObject.GetComponent<Image>().color = blue;
    }

    public void PointerExit()
    {
        gameObject.GetComponent<Image>().color = normal;
    }

    public void PointerClick()
    {
        audioScript.SFXs[4].Play();
        gameObject.GetComponent<Image>().color = darkBlue;
    }
}
