using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int points = 50;

    void OnCollisionEnter(Collision other)
    {
        GameLogic.instance.AddScore(points);

        Destroy(gameObject);
    }
}
