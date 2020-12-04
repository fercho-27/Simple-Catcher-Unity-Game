using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystick : MonoBehaviour{
    public float speed = 0f, maxSpeed = 7.5f, maxVel = 6f;
    private Rigidbody2D player;
    private Animator anim;
    private int cont;

    [HideInInspector]
    public bool checador;

    public static bool parpadeoActivo;
    private bool moveLeft, moveRight;

    void Awake() {
        player = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        checador = PlayerScore.meteoroTocado;
        parpadeoActivo = false;
    }

    void FixedUpdate() {
        checador = PlayerScore.meteoroTocado;
        if (checador == false) {
            parpadeoActivo = true;
            cont++;
        }
        else {
            cont = 0;
        }

        if (cont >= 200) {
            checador = true;
            parpadeoActivo = false;
            PlayerScore.meteoroTocado = true;
        }

        if (moveLeft) {
            MoveLeft();
        }
        if (moveRight) {
            MoveRight();
        }
    }

    public void SetMoveLeft(bool moveLeft) {
        this.moveLeft = moveLeft;
        this.moveRight = !moveLeft;//Se hace las dos cosas aqui
    }

    public void StopMoving() {
        moveRight = moveLeft = false;
        if (checador) {
            anim.Play("Standing");
        }
        else {
            anim.Play("ParpadeoStanding");
        }
    }

    void MoveLeft() {
        float forceX = 0f;
        float vel = Mathf.Abs(player.velocity.x);
        if (speed < maxSpeed) speed += 2.5f;
        if (speed >= maxSpeed) speed = maxSpeed;

        if (vel < maxVel) forceX = -speed;
        Vector3 temp = this.transform.localScale;
        temp.x = 5f;
        this.transform.localScale = temp;
        if (checador) {
            anim.Play("Run");
        }
        else {
            anim.Play("ParpadeoRun");
        }

        player.AddForce(new Vector2(forceX, 0));
    }

    void MoveRight() {
        float forceX = 0f;
        float vel = Mathf.Abs(player.velocity.x);
        if (speed < maxSpeed) speed += 2.5f;
        if (speed >= maxSpeed) speed = maxSpeed;

        if (vel < maxVel) forceX = speed;
        Vector3 temp = this.transform.localScale;
        temp.x = -5f;
        this.transform.localScale = temp;
        if (checador) {
            anim.Play("Run");
        }
        else {
            anim.Play("ParpadeoRun");
        }
        player.AddForce(new Vector2(forceX, 0));
    }

  
}
