using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public static GameLogic instance = null;

    public GameObject paddlePrefab;
    GameObject paddle;
    GameObject ball;

    public Text scoreText;
    public Text gameOver;

    public int highscore = 0;
    public int lives = 3;

    void Awake()
    {
        if(instance == null)
            instance = this;   
    }

    void Start()
    {
        CreatePaddle();

        gameOver.gameObject.SetActive(false);
        scoreText.text = string.Format("Score: {0}", highscore);
    }

    void CreatePaddle()
    {
        paddle = GameObject.Instantiate(paddlePrefab);

        ball = paddle.GetComponentInChildren<Ball>().gameObject;
    }

    void Reset()
    {
        Destroy(paddle);
        Destroy(ball);
        CreatePaddle();
    }

    public void AddScore(int score)
    {
        highscore += score;

        scoreText.text = string.Format("Score: {0}", highscore);
    }

    public void BallDead()
    {
        if(--lives > 0)
            Reset();
        else
            GameOver();
    }

    void GameOver()
    {
        gameOver.gameObject.SetActive(true);
        Invoke("ResetGame",2f);
    }

    void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
