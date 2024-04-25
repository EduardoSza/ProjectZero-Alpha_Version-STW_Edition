using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private GameObject joystick;
    [SerializeField]
    private AudioSource gameBackgroundMusic;
    [SerializeField]
    private TextMeshProUGUI gameScoreText;

    public static GameController instance;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameScoreText.text = "PLAYER SCORE:\n" + GlobalVariables.gameScore.ToString();
        instance = this;
    }

    void Update()
    {
        gameScoreText.text = "PLAYER SCORE:\n" + GlobalVariables.gameScore.ToString();
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        joystick.SetActive(false);
        gameBackgroundMusic.Stop();
        Time.timeScale = 0;
    }

    public void ShowOnPausePanel()
    {
        pausePanel.SetActive(true);
        joystick.SetActive(false);
        gameBackgroundMusic.Pause();
        Time.timeScale = 0;
    }

    public void ShowOffPausePanel()
    {
        pausePanel.SetActive(false);
        joystick.SetActive(true);
        gameBackgroundMusic.Play();
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
