using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    public bool lose = false;
    public GameObject LoseUi;
    public GameObject pause;
    private PauseMenu pause_script;
    public GameObject victory;
    private Victory victory_script;

    void Start()
    {
        pause_script = pause.GetComponent<PauseMenu>();
        victory_script = victory.GetComponent<Victory>();
    }
    // Update is called once per frame
    void Update()
    {
        if (pause_script.GameIsPaused == false)
        {
            if (lose && victory_script.victory == false)
            {
                Message();
            }
        }
    }

    void Message()
    {
        LoseUi.SetActive(true);
        Time.timeScale = 1f;
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
