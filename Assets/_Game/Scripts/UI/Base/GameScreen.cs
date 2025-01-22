using UnityEngine;

// t��da GameScreen, kter� d�d� z MonoBehaviour -> m��e se pou��vat jako komponenta na hern�ch objektech
public class GameScreen : MonoBehaviour
{
    // typ obrazovky
    public GameScreenType GameScreenType;

    // metoda uzav�r� aktivn� screenu
    public void CloseScreen()
    {
        // event zav�e screenu
        ScreenEvents.OnGameScreenClosedInvoke(GameScreenType);
    }
}
