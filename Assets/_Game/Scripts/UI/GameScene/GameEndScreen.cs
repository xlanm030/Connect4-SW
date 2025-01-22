using TMPro;
using UnityEngine;

public class GameEndScreen : GameScreen
{
    // v�hern� text
    [SerializeField] private TMP_Text _playerWonText;

    // text p�i v�h�e a rem�ze
    private const string PLAYER_WON_TEXT_SUFFIX = " won!";
    private const string TIE_TEXT_SUFFIX = "Its a tie! No free fields left!";

    // p�i na�ten� screenu se vyp�e vhodn� text na z�klad� v�sledku hry
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

    // vr�cen� zp�t do menu
    public void GoToMenu()
    {
        SceneLoadManager.Instance.GoGameToMenu();
    }

    // ukon�en� hry
    public void Exit()
    {
        Application.Quit();
    }
}
