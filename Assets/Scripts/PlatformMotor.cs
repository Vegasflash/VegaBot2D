using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMotor : MonoBehaviour
{

    public float rightLimit = 2.5f;
    public float leftLimit = 1.0f;

    float thisRightLimit;
    float thisLeftLimit;

    public float speed = 2.0f;
    private int direction = 1;

    Vector3 movement;

    private void Start()
    {
        float thisRightLimit = transform.position.x + rightLimit;
        float thisLeftLimit = transform.position.x - leftLimit;  
    }

    void Update()
    {
        if (transform.position.x > thisRightLimit)
        {
            direction = -1;
        }
        else if (transform.position.x < thisLeftLimit)
        {
            direction = 1;
        }
        movement = Vector3.right * direction * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}
