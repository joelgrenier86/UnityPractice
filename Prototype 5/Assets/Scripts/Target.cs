using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    public int pointValue;
    private float minSpeed = 14.0f;
    private float maxSpeed = 17.0f;
    private float xRange = 4.0f;
    private float maxTorque = 10.0f;    
    private float ySpawnPos = -2.0f;
    private Rigidbody targetRb;
    private GameManager gameManager;
    // Start is called before the first frame update
    
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        //set targetRb to this object, fire it up into the air and give it a spin
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(
            RandomTorque(), RandomTorque(),
            RandomTorque(), ForceMode.Impulse);
            transform.position = RandomSpawnPos();
        
    }

    //3 methods to calculate random values with private variables above
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);

    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
    float RandomTorque(){
        return Random.Range(-maxTorque, maxTorque);
    }
    private void OnMouseDown() {
        Destroy(gameObject);
        if (gameManager.isGameActive){
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
   
    }
    private void OnTriggerEnter(Collider other){
        Destroy (gameObject);
        if (!gameObject.CompareTag("Bad")){
            gameManager.GameOver();
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
