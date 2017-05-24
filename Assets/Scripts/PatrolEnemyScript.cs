using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemyScript : MonoBehaviour
{
    Transform enemyTransform;
    Rigidbody enemyRB;
    Animator enemyAnimator;


    public GameObject enemy;
    bool canFlip = true;
    bool facingRight = false;
    float flipTime = 5f;
    float nextFlipChance = 0f;

    float enemySpeed = 6f;
    float direction = 1f;

    // attacks

    public float delayTime = 1f;
    float startDelayTime;
    bool delaying;



	// Use this for initialization
	void Start ()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyRB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 forward = transform.TransformDirection(Vector3.left) * 10;
        Debug.DrawRay(transform.position, forward, Color.blue);
        if (Time.time > nextFlipChance)
        {
            if(Random.Range(0,10)>=5)
            {
                FlipFacing();
            }
            nextFlipChance = Time.time + flipTime;
        }
	}

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "WindWalker" || collider.tag == "Warrior" || collider.tag == "Sage" || collider.tag == "Ninja")
        {
            Debug.Log(collider);
            if(facingRight && collider.transform.position.x < transform.position.x)
            {
                FlipFacing();
            }
            else if(!facingRight && collider.transform.position.x > transform.position.x)
            {
                FlipFacing();
            }
            canFlip = false;
            delaying = true;
            startDelayTime = Time.time + delayTime;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.tag == "WindWalker" || collider.tag == "Warrior" || collider.tag == "Sage" || collider.tag == "Ninja")
        {
            canFlip = true;
            delaying = false;
            enemyRB.velocity = new Vector3(0f, 0f, 0f);
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if(collider.tag == "WindWalker" || collider.tag == "Warrior" || collider.tag == "Sage" || collider.tag == "Ninja")
        {
            if(startDelayTime >= Time.time)
            {
                if(!facingRight)
                {
                    enemyRB.AddForce(new Vector3(-5, 0, 0) * enemySpeed);
                }
                else
                {
                    enemyRB.AddForce(new Vector3(5, 0, 0) * enemySpeed);
                }
            }
        }
    }

    void FlipFacing()
    {
        if(!canFlip){return;}        
        float facingX = enemy.transform.localScale.x;
        facingX *= -1f;
        enemy.transform.localScale = new Vector3(facingX, enemy.transform.localScale.y,enemy.transform.localScale.z);
        facingRight = !facingRight;      
    }
}
