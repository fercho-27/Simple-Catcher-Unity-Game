using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
    [SerializeField]
    private Button musicBtn;

    [SerializeField]
    private Sprite[] musicIcons;

    // Start is called before the first frame update
    void Start() {
        CheckMusic();
    }

    public void CheckMusic() {
        if(GamePreferences.GetMusicState() == 1) {
            MusicController.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIcons[0];
        }
        else {
            MusicController.instance.PlayMusic(false);
            musicBtn.image.sprite = musicIcons[1];
        }
    }

    public void StartGame() {
        //SceneManager.LoadScene("Gameplay");
        SceneFader.instance.LoadLevel("Gameplay");
    }

    public void HighScoreMenu() {
        SceneFader.instance.LoadLevel("HighScore");
        //SceneManager.LoadScene("HighScore");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void MusicButton() {
        if(GamePreferences.GetMusicState() == 0) {
            GamePreferences.SetMusicState(1);
            MusicController.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIcons[0];
        }else if (GamePreferences.GetMusicState() == 1) {
            GamePreferences.SetMusicState(0);
            MusicController.instance.PlayMusic(false);
            musicBtn.image.sprite = musicIcons[1];
        }
    }


    // Update is called once per frame
    void Update() {
        
    }
}
