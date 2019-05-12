using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 0.8f;

    // Update is called once per frame
    void Update()
    {
        float newX = transform.position.x + Input.GetAxis("Horizontal") * speed;
        Vector3 newPos = new Vector3(Mathf.Clamp(newX,-10f,10f),0f,0f);
        transform.position = newPos;        
    }
}
