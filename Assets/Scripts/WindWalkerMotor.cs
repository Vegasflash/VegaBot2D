using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindWalkerMotor : MonoBehaviour
{
    Vector3 move;
    private Animator anim;
    private SpriteRenderer mySpriteRenderer;
    private Rigidbody2D rB2D;


    float gravity = 3f;
    float verticalVelocity = 0f;
    float jumpForce = 250f;
    float speed = 5f;
    float distToGround;
    int jumpCount = 1;
    float knockBack = 10f;
    int maxJumpCount = 2;
    bool isGrounded;
    bool player_is_moving;

    void Start()
    {
        anim = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        rB2D = GetComponent<Rigidbody2D>();
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
    }

    void Update()
    {
        //transform.Translate(Vector3.down * gravity * Time.deltaTime);
        if (Input.GetKey("d"))
        {
            FaceDirection(1);
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            //rB2D.AddForce(Vector3.right * speed);

            player_is_moving = true;              
        }
        else if(Input.GetKeyUp("d"))
        {
            anim.SetBool("isRunning", false);
        }
        if (Input.GetKey("a"))
        {
            FaceDirection(2);
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            //rB2D.AddForce(Vector3.left * speed);
            player_is_moving = true;
        }
        else if(Input.GetKeyUp("a"))
        {
            anim.SetBool("isRunning", false);
        }
        if (isGrounded)
        {
            if (Input.GetKeyDown("space"))
            {
                //transform.Translate(Vector3.up * jumpForce);
                anim.SetBool("isJumping", true);
                rB2D.AddForce(Vector3.up * jumpForce);
                isGrounded = false;
            }
        }
        else if (!isGrounded)
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().gameObject.tag == "Enemy")
        {
            print("you hit an enemy");
            move = new Vector3(-3, -3, 0);
            move = transform.TransformDirection(move);
            move *= knockBack;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor")
        {
            isGrounded = true;
            anim.SetBool("isJumping", false);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        //isGrounded = false;
    }

    public bool GetIsPlayerMoving()
    {
        return player_is_moving;
    }

    void FaceDirection(int direction)
    {        
        if(direction == 1)
        {
            if(isGrounded)
            {
                anim.SetBool("isRunning", true);
            }
            mySpriteRenderer.flipX = true;
        }   
        else if (direction == 2)
        {
            if(isGrounded)
            {
            anim.SetBool("isRunning", true);
            }
            mySpriteRenderer.flipX = false;
        }      
    }
}
