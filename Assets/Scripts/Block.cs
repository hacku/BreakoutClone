using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //Punkte pro Treffer
    public int points = 50;

    void OnCollisionEnter(Collision other)
    {
        //Punkte in Gamelogic registrieren
        GameLogic.instance.AddScore(points);
        //Block zerstören
        Destroy(gameObject);
    }
}
