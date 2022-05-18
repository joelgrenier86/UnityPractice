using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public Button restartButton;
    public bool isGameActive;
    private float spawnRate = 1.0f;

    public List<GameObject> targets;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    // Start is called before the first frame update
    void Start()
    {
    
        
    }
    public void StartGame(int difficulty){
        spawnRate /=difficulty;
            isGameActive = true;
        StartCoroutine(SpawnTarget());
        scoreText.text = "Score: " + score;
        titleScreen.gameObject.SetActive(false);
    }

    IEnumerator SpawnTarget() {
        while (isGameActive){
            yield return new WaitForSeconds (spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate (targets[index]);
        }
    }
    public void GameOver(){
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void UpdateScore(int scoreToAdd){
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
