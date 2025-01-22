using UnityEngine;

public class MenuCanvasController : BaseCanvasController
{
    // t��dy, kter� jsou viditeln� v Inspektoru
    [SerializeField] private MenuMainButtons _menuMainButtonsPrefab;
    [SerializeField] private GameSettingsScreen _gameSettingsScreenPrefab;

    // zavol� se p�i spu�t�n� instance skriptu
    private void Awake()
    {
        // metoda otev�e screen MenuMain
        ShowGameScreen(GameScreenType.MenuMain);
    }

    // p�et�en� metoda, kter� vrac� konkr�tn� screen
    protected override GameScreen GetRelevantScreen(GameScreenType gameScreenType)
    {
        return gameScreenType switch
        {
            // p�i spln�n� podm�nky, vytvo�� instanci prefabu
            GameScreenType.MenuMain => Instantiate(_menuMainButtonsPrefab, transform),
            GameScreenType.GameSettings => Instantiate(_gameSettingsScreenPrefab, transform),
            _ => base.GetRelevantScreen(gameScreenType),
        };
    }

    // p�et�en� metoda, kter� vrac� typ aktivn� screeny
    protected override GameScreenType GetActiveGameScreen(GameScreenType gameScreenType)
    {
        return gameScreenType switch
        {
            GameScreenType.GameSettings => GameScreenType.MenuMain,
            _ => base.GetActiveGameScreen(gameScreenType),
        };
    }
}
