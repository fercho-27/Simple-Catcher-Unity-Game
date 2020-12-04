using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour{
    [SerializeField]
    private GameObject readyButton;

    void Awake() {
        Time.timeScale = 0f;
    }

    public void StartTheGame() {
        Time.timeScale = 1f;
        readyButton.SetActive(false);
    }

}
