using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorMotor : MonoBehaviour
{
    CharacterController controller;

    float gravity = 3f;
    float verticalVelocity = 0f;
    float jumpForce = 2.1f;
    float speed = 3f;
    float knockBack = 10f;
    bool isLookingRight = true;

    Vector3 move = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        move.x = Input.GetAxis("Horizontal");

        FaceDirection();

        if (controller.isGrounded)
        {
            verticalVelocity = -1f;
            if (Input.GetKeyDown("space"))
            {
                verticalVelocity = verticalVelocity + jumpForce;
            }
        }
        else if (!controller.isGrounded)
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        move.y = verticalVelocity;
        controller.Move(move * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().gameObject.tag == "Enemy")
        {
            print("you hit an enemy");
            move = new Vector3(-3, -3, 0);
            move = transform.TransformDirection(move);
            move *= knockBack;
            controller.Move(move * Time.deltaTime);
        }
    }

    void FaceDirection()
    {
        if (Input.GetKeyDown("d") && isLookingRight == false)
        {
            transform.RotateAround(transform.position, transform.up, 180f);
            isLookingRight = true;
        }
        if (Input.GetKeyDown("a") && isLookingRight == true)
        {
            transform.RotateAround(transform.position, transform.up, 180f);
            isLookingRight = false;
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!controller.isGrounded && hit.normal.y < 0.1f)
        {
            if (Input.GetKey("w"))
            {
                Debug.DrawRay(hit.point, hit.normal, Color.green, 1.25f);
                verticalVelocity = 0.5f;
            }
        }
    }
}
