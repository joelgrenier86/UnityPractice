using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool hasPowerup;
    public GameObject powerupIndicator;
    public float powerupStrength = 15.0f;

    private GameObject focalPoint;
    private Rigidbody playerRb;
    float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find ("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        powerupIndicator.transform.position = transform.position;
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
            
    }
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Powerup")){
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }
    IEnumerator PowerupCountdownRoutine(){
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);

    }
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup){
            Debug.Log("THING");
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            //set the knockback direction here, kept awayfromplayer variable name
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);

        }
    }
}

