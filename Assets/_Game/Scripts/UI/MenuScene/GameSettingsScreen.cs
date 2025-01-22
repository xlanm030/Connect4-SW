using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;

public class GameSettingsScreen : GameScreen
{
    // prom�nn� viditeln� v inspektoru ur�uj�c� d�lku jm�na hr��e
    [SerializeField] private int _shortPlayerNameThreshold;
    [SerializeField] private int _longPlayerNameThreshold;

    // jm�na hr���
    [SerializeField] private TMP_InputField _playerOneName;
    [SerializeField] private TMP_InputField _playerTwoName;

    // text errorov� hl�ky
    [SerializeField] private TMP_Text _errorText;

    // chybov� hl�ky
    private const string ERROR_EMPTY_PLAYER_ONE_NAME = "Please fill out player one name!";
    private const string ERROR_EMPTY_PLAYER_TWO_NAME = "Please fill out player two name!";
    private const string ERROR_SHORT_PLAYER_ONE_NAME = "Player one name is too short!";
    private const string ERROR_SHORT_PLAYER_TWO_NAME = "Player two name is too short!";
    private const string ERROR_LONG_PLAYER_ONE_NAME = "Player one name is too long!";
    private const string ERROR_LONG_PLAYER_TWO_NAME = "Player two name is too long!";
    private const string ERROR_SAME_PLAYER_NAMES = "Players cannot have same names!";

    // metoda se pokus� spustit hru
    public void SaveAndPlay()
    {
        if (HandleErrorMessages())
        {
            return;
        }

        // ulo�� se nastaven� a p�epne se sc�na na hru
        SaveGameSettings();
        SceneLoadManager.Instance.GoMenuToGame();
    }

    // ulo�en� nastaven� hry
    private void SaveGameSettings()
    {
        // p�i�azen� jmen hr���m z inputu
        GameManager.Instance.PlayerOneName = _playerOneName.text;
        GameManager.Instance.PlayerTwoName = _playerTwoName.text;
    }

    // ov��uje inputy od hr���
    private bool HandleErrorMessages()
    {
        // seznam ov��en�
        Dictionary<Func<bool>, string> validations = new()
        {
            { () => string.IsNullOrEmpty(_playerOneName.text), ERROR_EMPTY_PLAYER_ONE_NAME },
            { () => string.IsNullOrEmpty(_playerTwoName.text), ERROR_EMPTY_PLAYER_TWO_NAME },
            { () => _playerOneName.text.Length < _shortPlayerNameThreshold, ERROR_SHORT_PLAYER_ONE_NAME },
            { () => _playerTwoName.text.Length < _shortPlayerNameThreshold, ERROR_SHORT_PLAYER_TWO_NAME },
            { () => _playerOneName.text.Length > _longPlayerNameThreshold, ERROR_LONG_PLAYER_ONE_NAME },
            { () => _playerTwoName.text.Length > _longPlayerNameThreshold, ERROR_LONG_PLAYER_TWO_NAME },
            { () =>  string.Equals(_playerOneName.text, _playerTwoName.text), ERROR_SAME_PLAYER_NAMES },
        };

        // kontrola v�ech ov��en�
        foreach (KeyValuePair<Func<bool>, string> validation in validations)
        {
            if (validation.Key())
            {
                ShowErrorText(validation.Value);
                return true;
            }
        }

        HideErrorText();
        return false;
    }

    // zobrazen� errorov� hl�ky
    private void ShowErrorText(string errorText)
    {
        _errorText.gameObject.SetActive(true);
        _errorText.text = errorText;
    }

    // schov� errorovou hl�ku
    private void HideErrorText()
    {
        _errorText.gameObject.SetActive(false);
    }
}
