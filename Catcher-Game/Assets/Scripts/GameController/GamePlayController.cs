using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour{
    public static GamePlayController instance;


    [SerializeField]
    private Text scoreText, lifeText, finalScore;

    public GameObject x2;
    public GameObject invincible;

    [SerializeField]
    private GameObject pausePanel, gameOverPanel;

    void Awake() {
        MakeInstance();
    }

    void MakeInstance() {
        if(instance == null) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start(){
        
    }

    public void SetScore(int score) {
        scoreText.text = "x" + score;
    }

    public void SetLifeScore(int score) {
        lifeText.text = "x" + score;
    }

    public void GameOverShowPanel(string finalScore) {
        gameOverPanel.SetActive(true);
        this.finalScore.text = finalScore;
    }

    public void PausePanel() {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ReturnTheGame() {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void QuitGame() {
        Time.timeScale = 1f;
        //SceneManager.LoadScene("MainMenu");
        SceneFader.instance.LoadLevel("MainMenu");
    }

    public void RestartGame() {
        Time.timeScale = 1f;
        //SceneManager.LoadScene("Gameplay");
        SceneFader.instance.LoadLevel("Gameplay");
    }

    // Update is called once per frame
    void Update(){
        if(lifeText.text == "x-1") {
            lifeText.text = "x0";
            GameManager.instance.CheckGameStatus(scoreText.text);
            GameOverShowPanel(scoreText.text);
            Time.timeScale = 0;
        }
    }
}
