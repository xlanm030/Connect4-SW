using System.Collections.Generic;
using UnityEngine;

public class BaseCanvasController : MonoBehaviour
{
    public GameScreen ActiveGameScreen;

    protected Dictionary<GameScreenType, GameScreen> _instantiatedScreens = new();

    // po aktivaci objektu se pøihlásí metody k eventùm
    private void OnEnable()
    {
        ScreenEvents.OnGameScreenOpened += ShowGameScreen;
        ScreenEvents.OnGameScreenClosed += CloseGameScreen;
    }

    // po deaktivaci objektu se odhlásí metody od eventù
    private void OnDisable()
    {
        ScreenEvents.OnGameScreenOpened -= ShowGameScreen;
        ScreenEvents.OnGameScreenClosed -= CloseGameScreen;
    }

    // zobrazí game screenu, pokud již neexistuje její instance
    protected void ShowGameScreen(GameScreenType gameScreenType)
    {
        if ((_instantiatedScreens.ContainsKey(gameScreenType) && _instantiatedScreens[gameScreenType] == null) ||
            !_instantiatedScreens.ContainsKey(gameScreenType))
        {
            InstantiateScreen(gameScreenType);
        }
    }

    // zavøe game screenu - znièí, pokud je instancovaná
    protected void CloseGameScreen(GameScreenType gameScreenType)
    {
        if (_instantiatedScreens.ContainsKey(gameScreenType))
        {
            GameScreenType nextScreenType = GetActiveGameScreen(gameScreenType);
            if (nextScreenType != GameScreenType.None)
            {
                if (!_instantiatedScreens.TryGetValue(nextScreenType, out GameScreen existingScreen) || existingScreen == null)
                {
                    InstantiateScreen(nextScreenType);
                }
            }

            Destroy(_instantiatedScreens[gameScreenType].gameObject);
            _instantiatedScreens.Remove(gameScreenType);
        }
    }

    // instancuje screenu
    private void InstantiateScreen(GameScreenType gameScreenType)
    {
        GameScreen screenInstance = GetRelevantScreen(gameScreenType);
        InstantiateScreen(screenInstance);
    }

    // instancuje screenu pokud není prázdná
    private void InstantiateScreen(GameScreen screenInstance)
    {
        if (screenInstance != null)
        {
            _instantiatedScreens[screenInstance.GameScreenType] = screenInstance;
            ActiveGameScreen = screenInstance;
        }
    }

    // vrací konkrétní screen
    protected virtual GameScreen GetRelevantScreen(GameScreenType gameScreenType)
    {
        return gameScreenType switch
        {
            _ => null
        };
    }

    // vrací aktivní screen
    protected virtual GameScreenType GetActiveGameScreen(GameScreenType gameScreenType)
    {
        return gameScreenType switch
        {
            _ => GameScreenType.None
        };
    }
}
