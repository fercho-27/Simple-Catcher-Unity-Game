using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePreferences {
    public static string IsMusicOn = "IsMusicOn";
    public static string Score = "Score";

    public static int GetMusicState() {
        return PlayerPrefs.GetInt(GamePreferences.IsMusicOn);
    }

    public static void SetMusicState(int state) {
        PlayerPrefs.SetInt(GamePreferences.IsMusicOn, state);
    }

    public static string GetHighScore() {
        return PlayerPrefs.GetString(GamePreferences.Score);
    }

    public static void SetHighScore(string state) {
        PlayerPrefs.SetString(GamePreferences.Score, state);
    }
}
