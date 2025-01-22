using System;

public static class ScreenEvents
{
    // spust� se event po otev�en� screeny
    public static event Action<GameScreenType> OnGameScreenOpened;

    // spu�t�n� eventu
    public static void OnGameScreenOpenedInvoke(GameScreenType gameScreenType)
    {
        OnGameScreenOpened?.Invoke(gameScreenType);
    }

    // spust� se event po uzav�en� screeny
    public static event Action<GameScreenType> OnGameScreenClosed;

    // spu�t�n� eventu
    public static void OnGameScreenClosedInvoke(GameScreenType gameScreenType)
    {
        OnGameScreenClosed?.Invoke(gameScreenType);
    }
}
