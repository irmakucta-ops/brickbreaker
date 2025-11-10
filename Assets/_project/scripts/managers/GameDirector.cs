using JetBrains.Annotations;
using UnityEngine;

public class GameDirector : MonoBehaviour
{

    public LevelManager levelManager;
    public AudioManager audioManager;
    public PowerupManager powerupManager;


    public FXManager fxManager;

    public MainUI mainUI;
    public FailUI failUI;

    private void Start()
    {
        mainUI.ShowMainMenu();
        failUI.Hide();

    }
    public void RestartLevel()
    { 
    levelManager.RestartLevelManager();
    }
    public void Win()
    {
        PlayerPrefs.SetInt("HighestLevelReached", levelManager.levelNo + 1);
        mainUI.ShowWinUI();
        levelManager.StopLevel();
    }
    public void Lose()
    {
        mainUI.ShowFailUI();
    }
    public void LoadNextLevel()
    {
        levelManager.levelNo++;
        levelManager.RestartLevelManager();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            levelManager.RestartLevelManager();

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            levelManager.levelNo++;
            levelManager.RestartLevelManager();
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            levelManager.levelNo--;
            levelManager.RestartLevelManager();
        }
    }
}
