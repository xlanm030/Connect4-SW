using UnityEngine;

public class PauseMenuScreen : GameScreen
{
    // pokraèování ve høe
    public void Resume()
    {
        // zavøe se pause menu screen
        Time.timeScale = 1;
        CloseScreen();
    }

    // zapne hru odznova
    public void Restart()
    {
        SceneLoadManager.Instance.RestartGame();
    }

    // naète menu
    public void GoToMenu()
    {
        SceneLoadManager.Instance.GoGameToMenu();
    }

    // ukonèí hru
    public void Exit()
    {
        Application.Quit();
    }
}
