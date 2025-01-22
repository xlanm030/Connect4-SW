using UnityEngine;

public class SceneLoadManager : MonoSingleton<SceneLoadManager>
{
    // roz���en� inicializace
    protected override void Init()
    {
        base.Init();
        GoBootToMenu();
    }

    // po na�ten� hry se zobraz� menu
    public void GoBootToMenu()
    {
        Time.timeScale = 1;
        SceneLoader.OnSceneLoadDone += OnBootToMenuLoadDone;
        SceneLoader.LoadScene(SceneLoader.Scenes.MenuScene);
    }

    private void OnBootToMenuLoadDone(SceneLoader.Scenes scene)
    {
        SceneLoader.OnSceneLoadDone -= OnBootToMenuLoadDone;
    }

    // po na�ten� se zobraz� hra m�sto menu, kter� se zav�e
    public void GoMenuToGame()
    {
        Time.timeScale = 1;
        SceneLoader.OnSceneLoadDone += OnMenuToGameLoadDone;
        SceneLoader.LoadScene(SceneLoader.Scenes.GameScene, toUnload: SceneLoader.Scenes.MenuScene);
    }

    private void OnMenuToGameLoadDone(SceneLoader.Scenes scenes)
    {
        SceneLoader.OnSceneLoadDone -= OnMenuToGameLoadDone;
    }

    // po na�ten� se zobraz� menu m�sto hry, kter� se zav�e
    public void GoGameToMenu()
    {
        Time.timeScale = 1;
        SceneLoader.OnSceneLoadDone += OnGameToMenuLoadDone;
        SceneLoader.LoadScene(SceneLoader.Scenes.MenuScene, toUnload: SceneLoader.Scenes.GameScene);
    }

    private void OnGameToMenuLoadDone(SceneLoader.Scenes scenes)
    {
        SceneLoader.OnSceneLoadDone -= OnGameToMenuLoadDone;
    }

    // po na�ten� zobraz� novou hru misto p�vodn� hry, kter� se zav�e
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneLoader.OnSceneLoadDone += OnRestartGameDone;
        SceneLoader.LoadScene(SceneLoader.Scenes.GameScene, toUnload: SceneLoader.Scenes.GameScene);
    }

    private void OnRestartGameDone(SceneLoader.Scenes scenes)
    {
        SceneLoader.OnSceneLoadDone -= OnRestartGameDone;
        GameManager.Instance.Restart();
    }

    // kontrola na�ten� konkr�tn� sc�ny
    public bool IsSceneLoaded(SceneLoader.Scenes sceneToCheck)
    {
        return SceneLoader.IsSceneLoaded(sceneToCheck);
    }
}
