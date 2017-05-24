using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    Vector3 newPosition;
    private SpriteRenderer mySpriteRenderer;
    private Animator animator;
    private float speed = 5f;
    
    void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
	void Start ()
    {
        newPosition = Vector3.right;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKey("a"))
        {
            transform.position -= newPosition * speed * Time.deltaTime;
            animator.SetBool("isRunning", true);
            mySpriteRenderer.flipX = true;
        }
        else if (Input.GetKey("d"))
        {
            animator.SetBool("isRunning", true);
            transform.position += newPosition * speed * Time.deltaTime;
            mySpriteRenderer.flipX = false;
        }
        else
            animator.SetBool("isRunning", false);
    }
}
