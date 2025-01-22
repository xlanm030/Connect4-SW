using UnityEngine;

// tøída obsluhující hlavní menu
public class MenuMainButtons : GameScreen
{
    // metoda spustí hru
    public void PlayTheGame()
    {
        // metoda uzavøe aktivní screenu
        CloseScreen();
        // metoda spouští otevøení screeny nastavení hry
        ScreenEvents.OnGameScreenOpenedInvoke(GameScreenType.GameSettings);
    }

    //metoda ukonèí hru
    public void ExitGame()
    {
        // uzavøení aplikace
        Application.Quit();
    }
}
