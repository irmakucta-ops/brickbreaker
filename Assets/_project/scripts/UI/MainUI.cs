using System;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public GameDirector gameDirector;

    public MainMenu mainMenu;
    public FailUI failUI;

    public WinUI winUI; 

    public void ShowMainMenu()
    {
        mainMenu.Show();
        failUI.Hide();
        winUI.Hide();  
    }

    public void ShowFailUI()
    {
        failUI.Show();
    }

    public void HideFailUI()
    {
        failUI.Hide();
    }

    public void StartGameButtonPressed()
    {
        gameDirector.RestartLevel();
        mainMenu.Hide();
    }

    public void RetryButtonPressed()
    {
        gameDirector.RestartLevel();
        failUI.Hide();
    }
    public void LoadNextLevelButtonPressed()
    {
        gameDirector.LoadNextLevel();
        winUI.Hide();
    }
    public void ShowWinUI()
    {
        winUI.Show(); 
    }

    public void QuitButtonPressed()
    {
        Application.Quit();
    }
}
