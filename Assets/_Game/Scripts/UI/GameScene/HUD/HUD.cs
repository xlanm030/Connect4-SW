using TMPro;
using UnityEngine;

public class HUD : GameScreen
{
    // pole pro jméná hráèù
    [SerializeField] private TMP_Text _playerOneName;
    [SerializeField] private TMP_Text _playerTwoName;

    // nastavení jmen hráèù
    private void Start()
    {
        _playerOneName.text = GameManager.Instance.PlayerOneName;
        _playerTwoName.text = GameManager.Instance.PlayerTwoName;
    }
}
