using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    //Singleton der Logic für andere Komponenten im Spiel
    public static GameLogic instance = null;

    //Schablone vom Paddle
    public GameObject paddlePrefab;

    //aktuelle Instanz vom Paddle (wird aus Schablone erzeugt)
    GameObject paddle;
    //aktuelle Instanz vom Ball
    GameObject ball;

    //UI-Element für Punkte
    public Text scoreText;

    //UI-Element für Game Over
    public Text gameOver;

    //Aktueller Punktestand
    public int score = 0;
    //Verbleibende Leben
    public int lives = 3;

    void Awake()
    {
        //Singleton erzeugen
        if(instance == null)
            instance = this;   
    }

    void Start()
    {
        //Spieler erzeugen
        CreatePaddle();

        //Game Over Text ausblenden
        gameOver.gameObject.SetActive(false);
        //Punkte-Text auf 0 setzen
        SetScoreText();
    }

    // Erzeugt ein neues Paddle und speichert das Paddle und den Ball
    void CreatePaddle()
    {
        //Objekt aus Prefab (Schablone) instanziieren
        paddle = GameObject.Instantiate(paddlePrefab);

        //Ball mittels Ball-Skript finden und GameObject speichern
        ball = paddle.GetComponentInChildren<Ball>().gameObject;
    }

    //Setzt den Spielerzustand zurück
    void Reset()
    {   
        //Paddle und Ball zerstören
        Destroy(paddle);
        Destroy(ball);

        //"Frisches" Paddle erzeugen
        CreatePaddle();
    }

    //Punkte hochzählen
    public void AddScore(int points)
    {
        score += points;

        SetScoreText();
    }

    //UI-Element für Punktestand aktualisieren
    void SetScoreText()
    {
        scoreText.text = string.Format("Score: {0}", score);
    }

    //Ball ist im Aus gelandet
    public void BallDead()
    {
        //Solange Spieler noch Leben übrig hat, neu beginnen, ansonsten Game Over
        if(--lives > 0)
            Reset();
        else
            GameOver();
    }

    //Spieler hat keine Leben mehr übrig
    void GameOver()
    {
        //Text einblenden
        gameOver.gameObject.SetActive(true);
        //Zwei Sekunden warten, danach Spiel neustarten
        Invoke("ResetGame",2f);
    }

    //Startet das Spiel neu
    void ResetGame()
    {
        //Durch erneutes Laden des aktuellen Levels wird der Anfangszustand wiederhergestellt
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
