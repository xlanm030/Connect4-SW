using UnityEngine;

public class MenuCanvasController : BaseCanvasController
{
    // tøídy, které jsou viditelné v Inspektoru
    [SerializeField] private MenuMainButtons _menuMainButtonsPrefab;
    [SerializeField] private GameSettingsScreen _gameSettingsScreenPrefab;

    // zavolá se pøi spuštìní instance skriptu
    private void Awake()
    {
        // metoda otevøe screen MenuMain
        ShowGameScreen(GameScreenType.MenuMain);
    }

    // pøetížená metoda, která vrací konkrétní screen
    protected override GameScreen GetRelevantScreen(GameScreenType gameScreenType)
    {
        return gameScreenType switch
        {
            // pøi splnìní podmínky, vytvoøí instanci prefabu
            GameScreenType.MenuMain => Instantiate(_menuMainButtonsPrefab, transform),
            GameScreenType.GameSettings => Instantiate(_gameSettingsScreenPrefab, transform),
            _ => base.GetRelevantScreen(gameScreenType),
        };
    }

    // pøetížená metoda, která vrací typ aktivní screeny
    protected override GameScreenType GetActiveGameScreen(GameScreenType gameScreenType)
    {
        return gameScreenType switch
        {
            GameScreenType.GameSettings => GameScreenType.MenuMain,
            _ => base.GetActiveGameScreen(gameScreenType),
        };
    }
}
