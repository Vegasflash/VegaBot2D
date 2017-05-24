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
    float jumpForce = 100f;
    float speed = 5f;
    float distToGround;
    int jumpCount = 1;
    float knockBack = 10f;
    int maxJumpCount = 2;
    bool isGrounded;

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
        if (isGrounded)
        {
            if(Input.GetKey("d"))
            {
                FaceDirection();
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            if(Input.GetKey("a"))
            {
                FaceDirection();
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            if(Input.GetKey("space"))
            {
                rB2D.AddForce(Vector3.up * jumpForce);           
            }
        }
        else if(!isGrounded)
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
            Debug.Log(col.gameObject.tag);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {

        isGrounded = false;
    }

    void FaceDirection()
    {        
        if(Input.GetKeyDown("d"))
        {
            anim.SetBool("isRunning", true);
            mySpriteRenderer.flipX = true;
        }
      
        if (Input.GetKeyDown("a"))
        {
            mySpriteRenderer.flipX = false;
            anim.SetBool("isRunning", true);
        }
        
    }
}
