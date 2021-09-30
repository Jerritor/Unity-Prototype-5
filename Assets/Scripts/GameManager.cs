using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //game state
    public bool isGameActive;
    public Button restartButton;

    private float spawnRate = 1.0f;
    private int score;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    public List<GameObject> targets;

    public GameObject titleScreen;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(int difficulty)
    {
        //hide title screen
        titleScreen.gameObject.SetActive(false);

        //set spawnrate based on difficulty
        spawnRate /= difficulty;

        //start game
        isGameActive = true;

        StartCoroutine(SpawnTarget());

        score = 0;
        UpdateScore(0);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        string txt = "Score: " + score;
        scoreText.text = txt;
    }


    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
