using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour{

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name != "Player") {
            Destroy(collision.gameObject);
        }
        
    }

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }
}
