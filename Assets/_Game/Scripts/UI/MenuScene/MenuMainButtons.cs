using UnityEngine;

public class MenuMainButtons : GameScreen
{
    public void PlayTheGame()
    {
        CloseScreen();
        // metoda ze t�idy ScreenEvents, kter� spou�t� otev�en� screeny
        ScreenEvents.OnGameScreenOpenedInvoke(GameScreenType.GameSettings);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
