using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    private Animator playerAnim;
    public float jumpForce;
    public float gravMod;
    public bool gameOver = false;
    public bool isOnGround = true;
    private Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>(); 
        Physics.gravity *= gravMod;
     //  playerRb.AddForce(Vector3.up * 1000);
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver){
           playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
           isOnGround = false;
           dirtParticle.Stop();
           playerAudio.PlayOneShot(jumpSound, 1.0f);
           playerAnim.SetTrigger("Jump_trig");
       } 

    }
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Ground")){
            dirtParticle.Play();
            isOnGround = true;
        }
        else if(collision.gameObject.CompareTag("Obstacle")){
            gameOver = true;

            Debug.Log("game over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            playerAudio.PlayOneShot(crashSound, 1.0f);
            explosionParticle.Play();
            dirtParticle.Stop();
        }
    }
 }
        
    

