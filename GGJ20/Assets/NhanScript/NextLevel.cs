using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    bool win = false;
    bool lost = false;
    public GameObject winMenu;
    public GameObject lostMenu;
    public Image oxygen;

    public static NextLevel Instance;

    void Awake()
    {
         Instance = this;
    }

    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)) // change this
        {
            win = true;
        }

        if (win)
        {
            winCodition();
        }

        if (oxygen.fillAmount == 0.0f)
        {
            lost = true;
        }

        if (lost)
        {
            lostCodition();
        }
    }

    public void winCodition()
    {
        winMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    void lostCodition()
    {
        lostMenu.SetActive(true);
        Time.timeScale = 0f;
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

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void repeatLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

}
