using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject pauseMenuUi;

    public GameObject victory;
    private Victory victory_script;

    public GameObject lose;
    private Lose lose_script;

    void Start() 
    {
        victory_script = victory.GetComponent<Victory>();
        lose_script = lose.GetComponent<Lose>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && victory_script.victory == false && lose_script.lose == false) 
        {
            if (GameIsPaused) 
            {
                Resume();
            } 
            else 
            {
                Pause();            
            }
        }
    }
    public void Resume() 
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause() 
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
