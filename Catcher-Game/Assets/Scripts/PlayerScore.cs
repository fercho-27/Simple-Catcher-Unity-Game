using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour{
    [SerializeField]
    private AudioClip estrellaSonido, meteoritoSonido;


    public static int score = 0;
    public static int lifeScore = 2;
    public static int cont1 = 0;
    public static int cont2 = 0;

    public static bool meteoroTocado;
    public static bool estrellaDoblePuntos;
    public static bool invensibilidad;
    private GamePlayController gameplay;

    // Start is called before the first frame update
    void Awake(){
        gameplay = GameObject.Find("GameplayController").GetComponent<GamePlayController>();
        gameplay.SetScore(0);
        gameplay.SetLifeScore(2);
        meteoroTocado = true;
        estrellaDoblePuntos = false;
        invensibilidad = false;

        score = 0;
        lifeScore = 2;
        cont1 = 0;
        cont2 = 0;
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "EstrellaAmarilla") {
            if (estrellaDoblePuntos) {
                score = score + 200;
            } else {
                score = score + 100;
            }           
            gameplay.SetScore(score);
            AudioSource.PlayClipAtPoint(estrellaSonido, transform.position);
            target.gameObject.SetActive(false);
        }
        if (target.tag == "EstrellaNaranja") {
            if (estrellaDoblePuntos) {
                score = score + 600;
            }
            else {
                score = score + 300;
            }
            gameplay.SetScore(score);
            AudioSource.PlayClipAtPoint(estrellaSonido, transform.position);
            target.gameObject.SetActive(false);
        }
        if (target.tag == "EstrellaRoja") {
            if (estrellaDoblePuntos) {
                score = score + 1000;
            }
            else {
                score = score + 500;
            }
            gameplay.SetScore(score);
            AudioSource.PlayClipAtPoint(estrellaSonido, transform.position);
            target.gameObject.SetActive(false);
        }
        if (target.tag == "EstrellaAzul") {
            invensibilidad = true; //////
            Debug.Log(invensibilidad);
            gameplay.invincible.SetActive(true);
            AudioSource.PlayClipAtPoint(estrellaSonido, transform.position);
            target.gameObject.SetActive(false);
        }
        if (target.tag == "EstrellaVerde") {
            estrellaDoblePuntos = true;
            gameplay.x2.SetActive(true);
            AudioSource.PlayClipAtPoint(estrellaSonido, transform.position);
            target.gameObject.SetActive(false);
        }
        if (target.tag == "EstrellaCyan") {
            lifeScore = lifeScore + 1;
            gameplay.SetLifeScore(lifeScore);
            AudioSource.PlayClipAtPoint(estrellaSonido, transform.position);
            target.gameObject.SetActive(false);
        }
        if (target.tag == "EstrellaVioleta") {
            if (estrellaDoblePuntos) {
                score = score + 2000;
            }
            else {
                score = score + 1000;
            }
            gameplay.SetScore(score);
            AudioSource.PlayClipAtPoint(estrellaSonido, transform.position);
            target.gameObject.SetActive(false);
        }
        if (target.tag == "Meteorito") {
            if (Player.parpadeoActivo == false && invensibilidad == false) {
                Debug.Log(invensibilidad);
                lifeScore = lifeScore - 1;
                gameplay.SetLifeScore(lifeScore);
                meteoroTocado = false;
            } 
            target.gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(meteoritoSonido, transform.position);     
        }
    }


  

    // Update is called once per frame
    void FixedUpdate(){
        if (estrellaDoblePuntos == true) {
            cont1++;
        }
        else {
            cont1 = 0;
        }
        if (cont1 >= 500) {
            gameplay.x2.SetActive(false);
            estrellaDoblePuntos = false;
        }


        if (invensibilidad == true) {
            gameplay.invincible.GetComponent<UnityEngine.UI.Text>().text =
                "INVINCIBILITY: " + (500-cont2);
            cont2++;
        }
        else {
            cont2 = 0;
        }
        if (cont2 >= 500) {
            gameplay.invincible.SetActive(false);
            invensibilidad = false;
        }
    }
}
