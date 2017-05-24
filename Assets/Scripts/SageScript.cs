using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SageScript : MonoBehaviour
{
    CharacterController controller;
    public PlayerCam pCam;

    public ManaScript manaScript;
    Vector3 move = Vector3.zero;

    float speed = 2f;
    float gravity = -10f;
    float knockBack = 10f;
    float verticalVelocity = 0f;
    float jumpForce = 6f;
    float flightForce = 5f;
    float magicPower = 0f;
    float magicCharge = 1f;
    float airborneMagicCharge = 0.5f;
    bool isLookingRight = true;

	void Start()
    {
        controller = GetComponent<CharacterController>();
	}
	
	void Update()
    {
        move.x = Input.GetAxis("Horizontal") * speed;

        FaceDirection();

        if(controller.isGrounded)
        {
            verticalVelocity = -1;
            magicPower = 5f;
            manaScript.UpdateMagicPower(5f,magicPower);
            if(Input.GetKey("space"))
            {
                verticalVelocity = verticalVelocity + jumpForce;
            }
        }
        else
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                if(magicPower > 0)
                {
                    verticalVelocity += flightForce * Time.deltaTime;
                    magicPower -= magicCharge * Time.deltaTime;
                    manaScript.UpdateMagicPower(5f, magicPower);
                }
            }
            else if(!controller.isGrounded)
            {
                verticalVelocity += gravity * Time.deltaTime;
                manaScript.UpdateMagicPower(5f, magicPower);
                if(magicPower < 5)
                {
                    magicPower += airborneMagicCharge * Time.deltaTime;
                }
            }
        }
        move.y = verticalVelocity;
        controller.Move(move * speed * Time.deltaTime);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().gameObject.tag == "Enemy")
        {
            pCam.Shake(0.1f, 0.2f);
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
}
