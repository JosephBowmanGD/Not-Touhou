using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private ButtonManager resumeButton;
    [SerializeField] private ButtonManager menuButton;

    public bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
    }

    public void Close()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
        resumeButton.hasUnpressed = false;
        menuButton.hasUnpressed = false;
    }

    void Open()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        resumeButton.timeUnscaled = .7f;
    }
}
