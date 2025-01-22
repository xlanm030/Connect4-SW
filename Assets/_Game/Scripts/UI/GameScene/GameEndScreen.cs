using TMPro;
using UnityEngine;

public class GameEndScreen : GameScreen
{
    // výherní text
    [SerializeField] private TMP_Text _playerWonText;

    // text pøi výhøe a remíze
    private const string PLAYER_WON_TEXT_SUFFIX = " won!";
    private const string TIE_TEXT_SUFFIX = "Its a tie! No free fields left!";

    // pøi naètení screenu se vypíše vhodný text na základì výsledku hry
    private void Awake()
    {
        if (GameManager.Instance.IsTie)
        {
            _playerWonText.text = TIE_TEXT_SUFFIX;
        }
        else
        {
            _playerWonText.text = (GameManager.Instance.PlayerOneWon ? GameManager.Instance.PlayerOneName : GameManager.Instance.PlayerTwoName) + PLAYER_WON_TEXT_SUFFIX;
        }
    }

    // zapne hru odznova
    public void Restart()
    {
        SceneLoadManager.Instance.RestartGame();
    }

    // vrácení zpìt do menu
    public void GoToMenu()
    {
        SceneLoadManager.Instance.GoGameToMenu();
    }

    // ukonèení hry
    public void Exit()
    {
        Application.Quit();
    }
}
