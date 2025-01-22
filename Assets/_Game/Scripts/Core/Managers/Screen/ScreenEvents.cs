using System;

public static class ScreenEvents
{
    // spustí se event po otevøení screeny
    public static event Action<GameScreenType> OnGameScreenOpened;

    // spuštìní eventu
    public static void OnGameScreenOpenedInvoke(GameScreenType gameScreenType)
    {
        OnGameScreenOpened?.Invoke(gameScreenType);
    }

    // spustí se event po uzavøení screeny
    public static event Action<GameScreenType> OnGameScreenClosed;

    // spuštìní eventu
    public static void OnGameScreenClosedInvoke(GameScreenType gameScreenType)
    {
        OnGameScreenClosed?.Invoke(gameScreenType);
    }
}
