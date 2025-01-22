using UnityEngine;

// t��da obsluhuj�c� hlavn� menu
public class MenuMainButtons : GameScreen
{
    // metoda spust� hru
    public void PlayTheGame()
    {
        // metoda uzav�e aktivn� screenu
        CloseScreen();
        // metoda spou�t� otev�en� screeny nastaven� hry
        ScreenEvents.OnGameScreenOpenedInvoke(GameScreenType.GameSettings);
    }

    //metoda ukon�� hru
    public void ExitGame()
    {
        // uzav�en� aplikace
        Application.Quit();
    }
}
