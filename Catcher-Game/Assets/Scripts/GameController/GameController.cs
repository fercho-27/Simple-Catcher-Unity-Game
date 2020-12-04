using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour{
    public Camera cam;
    public GameObject [] estrellas;

    [HideInInspector]
    public float maxWidthEstrella;
    
    [HideInInspector]
    public float maxWidthMeteorito;

    private float velocidadSpawn;
    private float maxVelocidadSpawn;

    private float velocidadDeCaida;
    private float maxVelocidadDeCaida;

    // Start is called before the first frame update
    void Start(){
        if(cam == null) {
            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targerWidth = cam.ScreenToWorldPoint(upperCorner);

        

        float estrellaWidth = estrellas[0].GetComponent<Renderer>().bounds.extents.x;
        float meteoritoWidth = estrellas[7].GetComponent<Renderer>().bounds.extents.x;
        maxWidthEstrella = targerWidth.x - estrellaWidth;
        maxWidthMeteorito = targerWidth.x - estrellaWidth;
        velocidadSpawn = 2.0f;
        maxVelocidadSpawn = 0.15f;

        velocidadDeCaida = 5.0f;
        maxVelocidadDeCaida = 0.999f;
        StartCoroutine(Spawn());
    }


    IEnumerator Spawn() {
        yield return new WaitForSeconds(2.0f);
        while (true) {
            float random = Random.Range(1.0f, 101.0f);
            GameObject choose = estrellas[0];
            bool meteoro = false;

            if(random >= 1 && random <= 35) {//Amarilla
                choose = estrellas[0];
            }
            if (random > 35 && random <= 70) {//Meteoro
                choose = estrellas[7];
                meteoro = true;
            }
            if (random > 70 && random <= 80) {//Naranja
                choose = estrellas[1];
            }
            if (random > 80 && random <= 87) {//Roja
                choose = estrellas[2];
            }
            if (random > 87 && random <= 89) {//Azul
                choose = estrellas[3];
            }
            if (random > 89 && random <= 97) {//Verde
                choose = estrellas[4];
            }
            if (random > 97 && random <= 99) {//Cyan
                choose = estrellas[5];
            }
            if (random > 99 && random <= 100) {//Violeta
                choose = estrellas[6];
            }
           
            if (velocidadDeCaida > maxVelocidadDeCaida) {
                velocidadDeCaida = velocidadDeCaida - 0.1f;
                for(int i=0; i<estrellas.Length; i++) {
                    estrellas[i].GetComponent<Rigidbody2D>().drag = 
                        velocidadDeCaida;
                }
            }

            if (meteoro == false) {
                Vector3 spawnPositionEstrella = new Vector3(
                Random.Range(-maxWidthEstrella, maxWidthEstrella),
                transform.position.y,
                0.0f);
                Quaternion spawnRotationEstrella = Quaternion.identity;
                Instantiate(choose, spawnPositionEstrella, spawnRotationEstrella);
            }else {
                Vector3 spawnPositionMeteoro = new Vector3(
                Random.Range(-maxWidthMeteorito, maxWidthMeteorito),
                transform.position.y,
                0.0f);
                Quaternion spawnRotationMeteoro = Quaternion.identity;
                Instantiate(choose, spawnPositionMeteoro, spawnRotationMeteoro);
            }

            if (velocidadSpawn > maxVelocidadSpawn && velocidadSpawn > 1.9) {
                velocidadSpawn = velocidadSpawn - 0.05f;
            }else if(velocidadSpawn > maxVelocidadSpawn && velocidadSpawn <= 1.9) {
                velocidadSpawn = velocidadSpawn - 0.04f;
            }

            Debug.Log("Velocidad de caida: " + velocidadDeCaida
                + " Velocidad de spawn: " + velocidadSpawn);
            yield return new WaitForSeconds(velocidadSpawn);                 
        }

    }

    // Update is called once per frame
    void Update(){
        
    }
}
