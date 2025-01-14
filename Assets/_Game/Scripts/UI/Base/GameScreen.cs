using UnityEngine;

// t��da GameScreen, kter� d�d� z MonoBehaviour -> m��e se pou��vat jako komponenta na hern�ch objektech
public class GameScreen : MonoBehaviour
{
    // typ obrazovky
    public GameScreenType GameScreenType;

    // metoda CloseScreen, kter� zav�r� hern� obrazovku pomoc� zavol�n� statick�ho eventu v t��d� ScreenEvents
    public void CloseScreen()
    {
        ScreenEvents.OnGameScreenClosedInvoke(GameScreenType);
    }
}
