using UnityEngine;

public class PauseMenuScreen : GameScreen
{
    // pokra�ov�n� ve h�e
    public void Resume()
    {
        // zav�e se pause menu screen
        Time.timeScale = 1;
        CloseScreen();
    }

    // zapne hru odznova
    public void Restart()
    {
        SceneLoadManager.Instance.RestartGame();
    }

    // na�te menu
    public void GoToMenu()
    {
        SceneLoadManager.Instance.GoGameToMenu();
    }

    // ukon�� hru
    public void Exit()
    {
        Application.Quit();
    }
}
