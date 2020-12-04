using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour{
    private PlayerJoystick playerMove;

    void Start() {
        playerMove = GameObject.Find("Player").GetComponent<PlayerJoystick>();
    }

    public void Update() {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if (touchPosition.x < 0) {
                playerMove.SetMoveLeft(true);
            }
            else {
                playerMove.SetMoveLeft(false);
            }

        }
        else {
            playerMove.StopMoving();
        }
    }
}
