using UnityEngine;

public class GameCanvasController : BaseCanvasController
{
    // screen paus menu a end screen
    [SerializeField] private PauseMenuScreen _pauseMenuScreen;
    [SerializeField] private GameEndScreen _gameEndScreen;

    // zapínání a vypínání pause menu
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ActiveGameScreen != null && ActiveGameScreen.GameScreenType == GameScreenType.Pause)
            {
                ScreenEvents.OnGameScreenClosedInvoke(GameScreenType.Pause);
            }
            else
            {
                ScreenEvents.OnGameScreenOpenedInvoke(GameScreenType.Pause);
                Time.timeScale = 0;
            }
        }
    }

    // vrátí požadovanou screenu
    protected override GameScreen GetRelevantScreen(GameScreenType gameScreenType)
    {
        return gameScreenType switch
        {
            GameScreenType.Pause => Instantiate(_pauseMenuScreen, transform),
            GameScreenType.GameEnd => Instantiate(_gameEndScreen, transform),
            _ => base.GetRelevantScreen(gameScreenType),
        };
    }
}
