using UnityEngine;

// tøída GameScreen, která dìdí z MonoBehaviour -> mùže se používat jako komponenta na herních objektech
public class GameScreen : MonoBehaviour
{
    // typ obrazovky
    public GameScreenType GameScreenType;

    // metoda uzavírá aktivní screenu
    public void CloseScreen()
    {
        // event zavøe screenu
        ScreenEvents.OnGameScreenClosedInvoke(GameScreenType);
    }
}
