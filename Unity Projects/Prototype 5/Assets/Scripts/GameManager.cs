using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextShadow;
    public TextMeshProUGUI gameOverText1;
    public TextMeshProUGUI gameOverText2;
    public TextMeshProUGUI gameOverText3;
    public TextMeshProUGUI gameOverText4;
    private int lives = 3; 
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public bool isGameActive;
    public ParticleSystem explosion2;
    public Button restart;
    public GameObject titleScreen;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);


        }
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "" + score;
        scoreTextShadow.text = "" + score;
    }

    public void UpdateLives()
    {
        lives--;
       
        if (lives == 2)
        {
            explosion2.Play();
            Destroy(Heart1);
            
        }
        if (lives == 1)
        {
            explosion2.Play();
            Destroy(Heart2);
            
        }
        if( lives == 0)
        {
            explosion2.Play();
            Destroy(Heart3);
            
           GameOver();
        }
    }
    public void GameOver()
    {
        StartCoroutine(GameOverText());
        isGameActive = false;
        
    }
    IEnumerator GameOverText()
    {
        gameOverText1.gameObject.SetActive(true);
        if (gameOverText1.gameObject.activeSelf)
        {
            yield return new WaitForSeconds(0.5f);
            gameOverText2.gameObject.SetActive(true);
        }
        if (gameOverText2.gameObject.activeSelf)
        {
            yield return new WaitForSeconds(0.3f);
            gameOverText3.gameObject.SetActive(true);
        }
        if (gameOverText3.gameObject.activeSelf)
        {
            yield return new WaitForSeconds(0.7f);
            gameOverText4.gameObject.SetActive(true); 
        }
        if (gameOverText4.gameObject.activeSelf)
        {
            yield return new WaitForSeconds(2f);
            restart.gameObject.SetActive(true);
        }
    }

    public void StartGame(int difficult)
    {
        spawnRate /= difficult;
        StartCoroutine(Spawn());
        score = 0;
        scoreText.text = "" + score;
        scoreTextShadow.text = "" + score;
        UpdateScore(0);
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
    }

}
