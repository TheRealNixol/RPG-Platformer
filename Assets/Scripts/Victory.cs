using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Victory : MonoBehaviour
{
    public bool victory = false;
    public GameObject victoryUi;
    public GameObject pause;
    private PauseMenu pause_script;
    public GameObject lose;
    private Lose lose_script;


    void Start() 
    {
        pause_script = pause.GetComponent<PauseMenu>();
        lose_script = lose.GetComponent<Lose>();
    }
    // Update is called once per frame
    void Update()
    {
        if (pause_script.GameIsPaused==false) 
        {
            if (victory && lose_script.lose == false)
            {
                Message();
            }
        }
    }

    void Message()
    {
        victoryUi.SetActive(true);
        Time.timeScale = 0f;
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
