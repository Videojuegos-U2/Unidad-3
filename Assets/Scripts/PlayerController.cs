//Rosas Castillo Gabriela
// GDGS2102
// 10/10/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    // Particulas de exploción para el jugador
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    // Sonido para el videojuego
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        
    }
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
           //     método AddForce para hacer que el jugador salte al comienzo del juego
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
        
    }
    //Si chocan con el "Suelo", establece isOnGround = true , y si chocan con un "Obstáculo", establece gameOver = true
    // El jugador coliciona el obstaculo para terminar el juego
    private void OnCollisionEnter( Collision collision)
    {
     
      if(collision.gameObject.CompareTag("Ground"))
      {
         isOnGround = true;
         dirtParticle.Play();
      } else if(collision.gameObject.CompareTag("Obstacle"))
      {
        Debug.Log("Game Over");
        gameOver = true;
        // Se usa la variable playerAnim y se realiza la configuración de la animación para la caida del jugador
        playerAnim.SetBool("Death_b", true);
        playerAnim.SetInteger("DeathType_int", 1);
        explosionParticle.Play();
        dirtParticle.Stop();
        playerAudio.PlayOneShot(crashSound, 1.0f);
      }
    }
}
