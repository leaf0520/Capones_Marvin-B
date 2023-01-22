using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerSavedValues : MonoBehaviour
{
    public static PlayerSavedValues Instance;

    public int Score;
    public TextMeshProUGUI PlayerName;
    public TextMeshProUGUI PlayerScore;

    public TMP_InputField PlayerInput;

    private void Awake()
    {
        Instance = this;
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            if (PlayerInput != null)
            {
                PlayerInput.text = PlayerPrefs.GetString("PlayerName");
            }
            PlayerName.text = PlayerPrefs.GetString("PlayerName");
        }
        if (PlayerPrefs.HasKey("PlayerScore"))
        {
            PlayerScore.text = PlayerPrefs.GetInt("PlayerScore").ToString("000000");
            Score = PlayerPrefs.GetInt("PlayerScore");
        }
    }

    public void OnValueChangeInputFieldTMP()
    {
        PlayerName.text = PlayerInput.text;
        PlayerPrefs.SetString("PlayerName", PlayerInput.text);
    }

    public void AddScore(int value)
    {
        Score += value;
        PlayerScore.text = Score.ToString("000000");
        PlayerPrefs.SetInt("PlayerScore", Score);
    }
}
