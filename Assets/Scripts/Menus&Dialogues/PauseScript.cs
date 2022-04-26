using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class PauseScript : MonoBehaviour
{
    public GameObject PausePanel;
    public Slider volumeSlider;
    public TMP_Dropdown qualityDropdown;
    private bool gameIsPause;
    // Update is called once per frame

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex ==0)
        {
            PlayerPrefs.SetFloat("volume", 1f);
            PlayerPrefs.SetInt("quality", 5);
        }
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
        qualityDropdown.value = PlayerPrefs.GetInt("quality");

    }

    void Update()
    {
        if (FindObjectOfType<AudioScript>().activeNum >= 2 && Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("quality", qualityIndex);
    }

    public void Resume()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        gameIsPause = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
        qualityDropdown.value = PlayerPrefs.GetInt("quality");
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

    }

    public void MainMenu()
    {
        Destroy(FindObjectOfType<AudioScript>().gameObject);
        SceneManager.LoadScene(0);
    }
}
