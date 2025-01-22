using TMPro;
using UnityEngine;

public class HUD : GameScreen
{
    // pole pro jm�n� hr���
    [SerializeField] private TMP_Text _playerOneName;
    [SerializeField] private TMP_Text _playerTwoName;

    // nastaven� jmen hr���
    private void Start()
    {
        _playerOneName.text = GameManager.Instance.PlayerOneName;
        _playerTwoName.text = GameManager.Instance.PlayerTwoName;
    }
}
