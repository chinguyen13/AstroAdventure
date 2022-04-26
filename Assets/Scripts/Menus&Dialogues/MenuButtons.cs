using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuButtons : MonoBehaviour
{
    public GameObject panel;
    private StartingCamera cam;
    public GameObject panelText;
    private AudioScript audioScript;
    public GameObject optionPanel;
    public GameObject buttonPanel;
    private void Start()
    {
        cam = FindObjectOfType<StartingCamera>();
        cam.enabled = false;
        audioScript = FindObjectOfType<AudioScript>();
    }


    public void NewGame()
    {
        StartCoroutine(NewGameNow());
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Option()
    {
        optionPanel.SetActive(true);
        buttonPanel.SetActive(false);
    }

    public void Back()
    {
        optionPanel.SetActive(false);
        buttonPanel.SetActive(true);
    }

    IEnumerator NewGameNow()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        audioScript.activeNum = 1;
        panelText.SetActive(true);
        yield return new WaitForSeconds(42f);
        panelText.SetActive(false);
        panel.SetActive(false);
        cam.enabled = true;
    }





}
