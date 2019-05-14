using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Spielereingabe abfragen
        float inputX = Input.GetAxis("Horizontal");

        //Aktuelle Position von Paddle holen
        Vector3 newPos = transform.position;

        //Spielereingabe verarbeiten
        newPos.x += inputX;

        //Paddle darf nicht über das Spielfeld hinaus, Clamp() beschneidet den Wert
        newPos.x = Mathf.Clamp(newPos.x,-10f,10f);

        //Paddle-Position aktualisieren
        transform.position = newPos;        
    }
}
