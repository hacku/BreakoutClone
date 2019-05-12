using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody ballBody;
    bool started = false;

     void Start()
    {
        ballBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && !started)
        {
            transform.parent = null;

            ballBody.isKinematic = false;
            ballBody.AddForce(new Vector3(Random.Range(-600f,600f),0f,600f));
            started = true;
        }
    }
}
