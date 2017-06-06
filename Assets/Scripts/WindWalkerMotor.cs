using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindWalkerMotor : MonoBehaviour
{
    Vector3 move;
    private Animator anim;
    private SpriteRenderer mySpriteRenderer;
    private Rigidbody2D rB2D;
    RaycastHit2D hit;
    Collider2D col2D;
    public GunScript gun;
    public Projectile projectile;
    public GameObject attackBox;

    bool isFacingRight;
    float gravity = 3f;
    float verticalVelocity = 0f;
    float jumpForce = 300f;
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
        col2D = GetComponent<Collider2D>();
    }

    void Update()
    {
        hit = Physics2D.Raycast(transform.position, -Vector2.up, 1, 1 << LayerMask.NameToLayer("Boundary"));
        Debug.DrawRay(transform.position, -Vector2.up * 0.75f);

        if (hit.collider != null)
        {
            if (hit.distance > 1.0f)
            {
                anim.SetBool("isLanding", false);

            }
            if (hit.distance >= 0.75f && hit.distance <= 1f)
            {
                anim.SetBool("isJumping", false);
                Debug.Log("LANDING");
            }
            else if (hit.distance < 0.75f)
            {
                isGrounded = true;
                anim.SetBool("isJumping", false);
            }
        }
        else
        {
            isGrounded = false;
            anim.SetBool("isJumping", false);
        }

        //transform.Translate(Vector3.down * gravity * Time.deltaTime);
        if (Input.GetKey("d"))
        {
            FaceDirection(1);
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            //rB2D.AddForce(Vector3.right * speed);
            player_is_moving = true;
        }
        else if (Input.GetKeyUp("d"))
        {
            //CheckIfRunning(0.2f);
            anim.SetBool("isRunning", false);
        }
        if (Input.GetKey("a"))
        {
            FaceDirection(2);
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            //rB2D.AddForce(Vector3.left * speed);
            player_is_moving = true;
        }
        else if (Input.GetKeyUp("a"))
        {
            //CheckIfRunning(0.2f);
            anim.SetBool("isRunning", false);
        }
        if (isGrounded)
        {
            if (Input.GetKeyDown("space"))
            {
                //transform.Translate(Vector3.up * jumpForce);
                anim.SetBool("isJumping", true);
                rB2D.AddForce(Vector3.up * jumpForce);
            }
        }
        else if (!isGrounded)
        {
            anim.SetBool("isJumping", true);
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

    public bool GetIsPlayerMoving()
    {
        return player_is_moving;
    }

    void FaceDirection(int direction)
    {
        isFacingRight = !isFacingRight;
        if (direction == 1)
        {
            mySpriteRenderer.flipX = true;

            anim.SetBool("isRunning", true);
            attackBox.transform.localRotation = Quaternion.Euler(0, 180, 0);
            gun.GunShift(direction);

        }
        else if (direction == 2)
        {
            mySpriteRenderer.flipX = false;
            anim.SetBool("isRunning", true);
            attackBox.transform.localRotation = Quaternion.Euler(0, 0, 0);
            gun.GunShift(direction);
        }
    }

    IEnumerator CheckIfRunning(float time)
    {
        yield return new WaitForSeconds(time);

        if (!Input.GetKey("a") || !Input.GetKey("d"))
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            isGrounded = true;
        }
    }
}
