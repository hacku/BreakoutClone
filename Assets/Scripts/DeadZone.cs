using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //Gamelogic benachrichtigen, dass Ball verloren ist
        GameLogic.instance.BallDead();
    }
}
