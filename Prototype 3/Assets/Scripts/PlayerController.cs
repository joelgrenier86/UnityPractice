using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float gravMod;
    public bool gameOver = false;
    public bool isOnGround = true;
    private Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
       playerRb = GetComponent<Rigidbody>(); 
       Physics.gravity *= gravMod;
     //  playerRb.AddForce(Vector3.up * 1000);
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space) && isOnGround){
           playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
           isOnGround = false;
       } 

    }
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Ground")){

            isOnGround = true;
        }
        else if(collision.gameObject.CompareTag("Obstacle")){
            gameOver = true;
            Debug.Log("game over!");
        }
    }
 }
        
    

