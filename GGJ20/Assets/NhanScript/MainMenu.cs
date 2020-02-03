using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuHolder;
    public GameObject optionMenuHolder;
    public GameObject menuLevelHolder;
    int activeScreenResIndex;
    public Slider[] volumeSliders;
    public Toggle[] resolutionToggles;
    public int[] screenWidths;

    private void Start()
    {
        activeScreenResIndex = PlayerPrefs.GetInt("Screen res Index");
        bool isFullscreen = (PlayerPrefs.GetInt("fullscreen") == 1)?true:false;
    }

    public void playLevelOne()
    {
        SceneManager.LoadScene("Level 1 Remake");
        Time.timeScale = 1f;
    }

    public void playLevelTwo()
    {
        SceneManager.LoadScene("Level 2");
        Time.timeScale = 1f;
    }
    public void playLevelThree()
    {
        SceneManager.LoadScene("Level 3");
        Time.timeScale = 1f;
    }
    public void Play()
    {
        mainMenuHolder.SetActive(false);
        optionMenuHolder.SetActive(false);
        menuLevelHolder.SetActive(true);

    }
    public void Quit()
    {
        Application.Quit();
    }
    public void OptionMenu()
    {
        mainMenuHolder.SetActive(false);
        optionMenuHolder.SetActive(true);
        menuLevelHolder.SetActive(false);
    }
    public void Main()
    {
        mainMenuHolder.SetActive(true);
        optionMenuHolder.SetActive(false);
        menuLevelHolder.SetActive(false);
    }
    public void SetScreenSolution(int i)
    {
        if (resolutionToggles[i].isOn)
        {
            activeScreenResIndex = i;
            float aspectRatio = 16 / 9f;
            Screen.SetResolution(screenWidths[i], (int)(screenWidths[i] / aspectRatio), false);
            PlayerPrefs.SetInt("screen res index", activeScreenResIndex);
            PlayerPrefs.Save();

        }
    }

    public void SetFullScreen(bool isFullScreen)
    {
        for (int i = 0; i < resolutionToggles.Length; i++)
        {
            resolutionToggles[i].interactable = !isFullScreen;
        }

        if (isFullScreen)
        {
            Resolution[] allResolutions = Screen.resolutions;
            Resolution maxResolution = allResolutions[allResolutions.Length - 1];
            Screen.SetResolution(maxResolution.width, maxResolution.height, true);

        }
        else
        {
            SetScreenSolution(activeScreenResIndex);
        }

        PlayerPrefs.SetInt("fullscreen", ((isFullScreen) ? 1 : 0));
        PlayerPrefs.Save();
    }

    public void SetMasterVolume (float value)
    {

    }

    public void Music(float value)
    {
 

    }

    public void SoundEffect(float value)
    {
     

    }


}
