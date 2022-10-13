//Rosas Castillo Gabriela
// GDGS2102
// 10/10/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    //Variable de velocidad
    private float speed = 30;
    private PlayerController playerControllerScript;
    private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    // Velocidad y tiempo deel jugador
    void Update()
    {
        if (playerControllerScript.gameOver == false)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
    //If para saltar los obstaculos
            if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            {
                Destroy(gameObject);
            }
        }
               
    }
