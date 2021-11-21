using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI newBestScoreText;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject newHightScoreScreen;
    private BallMovement ballMovementScript;
    public int score;
    public bool gameOver = false;
    public bool isNewBestScore = false;
    
    // Start is called before the first frame update
    void Start()
    {
        ballMovementScript = GameObject.Find("Ball").GetComponent<BallMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        GameOverMenu();
        NewBestScore();
    }

    private void DifficulIncrease()
    {
        int scoreCounter = score;

        if (scoreCounter > 10)
        {
            ballMovementScript.ballSpeed += 3;

            scoreCounter = 0;
        }
    }

    private void GameOverMenu()
    {
        if (gameOver == true && isNewBestScore == false)
        {
            gameOverScreen.SetActive(true);
        }
        if (gameOver == true && isNewBestScore == true)
        {
            newHightScoreScreen.SetActive(true);
        }
    }

    private void NewBestScore()
    {
        if (MainManager.Instance.topScore < score)
        {
            isNewBestScore = true;

            if (gameOver == true)
            {
                MainManager.Instance.topScore = score;

                newBestScoreText.text = "Top Score: " + MainManager.Instance.topScore;
            }
            
        }
    }

}
