using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreController : MonoBehaviour{
    [SerializeField]
    private Text scoreText;

    public void BackToMainMenu() {
        //SceneManager.LoadScene("MainMenu");
        SceneFader.instance.LoadLevel("MainMenu");
    }

    void SetScore() {
        scoreText.text = GamePreferences.GetHighScore();
    }

    // Start is called before the first frame update
    void Start(){
        SetScore();
    }

    // Update is called once per frame
    void Update(){
        
    }
}
