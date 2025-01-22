using UnityEngine;

public class SceneLoadManager : MonoSingleton<SceneLoadManager>
{
    // rozšíøení inicializace
    protected override void Init()
    {
        base.Init();
        GoBootToMenu();
    }

    // po naètení hry se zobrazí menu
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

    // po naètení se zobrazí hra místo menu, které se zavøe
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

    // po naètení se zobrazí menu místo hry, která se zavøe
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

    // po naètení zobrazí novou hru misto pùvodní hry, která se zavøe
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

    // kontrola naètení konkrétní scény
    public bool IsSceneLoaded(SceneLoader.Scenes sceneToCheck)
    {
        return SceneLoader.IsSceneLoaded(sceneToCheck);
    }
}
