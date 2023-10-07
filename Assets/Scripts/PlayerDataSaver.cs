using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]

public struct PlayerData
{
    public string Name { get; set; }
    public int Score { get; set; }
}

public class PlayerDataSaver 
{
    private const string PLAYER_DATA_NAME_KEY = "PlayerName";
    private const string PLAYER_DATA_SCORE_KEY = "PlayerScore";

    public void SavePlayerData(PlayerData playerData)
    {
        PlayerPrefs.SetString(PLAYER_DATA_NAME_KEY, playerData.Name);
        PlayerPrefs.SetInt(PLAYER_DATA_SCORE_KEY, playerData.Score);
        PlayerPrefs.Save();
    }

    public PlayerData LoadPlayerData()
    {
        var data = new PlayerData()
        {
            Name = PlayerPrefs.GetString(PLAYER_DATA_NAME_KEY),
            Score = PlayerPrefs.GetInt(PLAYER_DATA_SCORE_KEY)
        };

        return data;
    }

    public void UpdateScore(PlayerData playerData, int newScore)
    {
        var data = playerData;
        data.Score = newScore;
        SavePlayerData(data);
    }
}
