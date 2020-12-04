using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 0f, maxSpeed = 7.5f, maxVel = 6f;
    private Rigidbody2D player;
    private Animator anim;
    private int cont;

    [HideInInspector]
    public bool checador;

    public static bool parpadeoActivo;

    void Awake() {
        player = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        checador = PlayerScore.meteoroTocado;
        parpadeoActivo = false;
    }

    void FixedUpdate() {
        checador = PlayerScore.meteoroTocado;
        if(checador == false) {
            parpadeoActivo = true;
            cont++;
        }else {
            cont = 0;
        }

        if(cont >= 200) {
            checador = true;
            parpadeoActivo = false;
            PlayerScore.meteoroTocado = true;
        }

        MovePlayer();
    }

    void MovePlayer() {
        float forceX = 0f;
        float vel = Mathf.Abs(player.velocity.x);
        float h = Input.GetAxisRaw("Horizontal");
        if (speed < maxSpeed) speed += 2.5f;
        if (speed >= maxSpeed) speed = maxSpeed;
        if (h > 0) {
            if (vel < maxVel) forceX = speed;
            Vector3 temp = this.transform.localScale;
            temp.x = -5f;
            this.transform.localScale = temp;
            if (checador) {
                anim.Play("Run");
            }else {
                anim.Play("ParpadeoRun");
            }

        }
        else if (h < 0) {
            if (vel < maxVel) forceX = -speed;
            Vector3 temp = this.transform.localScale;
            temp.x = 5f;
            this.transform.localScale = temp;
            if (checador) {
                anim.Play("Run");
            }else {
                anim.Play("ParpadeoRun");
            }
        }
        else {
            speed -= 3f;
        }
        if (speed <= 0f) {
            if (checador) {
                anim.Play("Standing");
            }else {
                anim.Play("ParpadeoStanding");
            }
            speed = 0f;
            player.AddForce(new Vector2(-forceX * 2f, 0));
        }
        player.AddForce(new Vector2(forceX, 0));
    }
}