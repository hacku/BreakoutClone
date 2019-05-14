using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Physik-Körper vom Ball
    Rigidbody ballBody;
    //Hat der Spieler schon geschossen?
    bool started = false;

     void Start()
    {
        //Physik-Komponente holen
        ballBody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        //Spieler schießt Ball los
        if(Input.GetButtonDown("Fire1") && !started)
        {
            //Parent-Beziehung zum Paddle auflösen
            transform.parent = null;
            //An die Physikengine übergeben
            ballBody.isKinematic = false;
            //Zufällige Stärke für Schussbewegung auf X-Achse erzeugen
            float xForce = Random.Range(-600f,600f);
            //Kraft auf Ball anwenden
            ballBody.AddForce(new Vector3(xForce,0f,600f));
            
            //Spieler hat geschossen
            started = true;
        }
    }
}
