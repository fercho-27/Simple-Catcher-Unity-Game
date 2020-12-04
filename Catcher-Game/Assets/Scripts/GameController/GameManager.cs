using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [HideInInspector]
    public int score, lifeScore;

    public AudioClip audio2;

    void Awake() {
        MakeSingleton();
    }

    void Start() {
        InitializeVariables();
    }

    void MakeSingleton() {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    void InitializeVariables() {
        if (!PlayerPrefs.HasKey("GameInitialized")) {
            GamePreferences.SetHighScore("0");
            GamePreferences.SetMusicState(0);
            PlayerPrefs.SetInt("GameInitialized", 123); //No importa, solo es para inicializarla
        }
    }

   public void CheckGameStatus(string score) {
        string highScore = GamePreferences.GetHighScore();
        int high = int.Parse(highScore.Trim(new char[] { 'x', 'X' }));
        int sco = int.Parse(score.Trim(new char[] {'x', 'X'}));
        if (high < sco) {
            GamePreferences.SetHighScore(score.Trim(new char[] { 'x', 'X' }));
        }
    }
}