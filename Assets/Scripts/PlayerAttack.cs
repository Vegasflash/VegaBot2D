using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private bool isAttacking = false;

    private float attackTimer = 0f;
    private float attackCoolDown = 0.3f;

    public Collider attackTrigger;

    private Animator anime;
	
    void Awake()
    {
        attackTrigger.enabled = false;
    }
	void Update ()
    {
		if(Input.GetKeyDown("f") && !isAttacking)
        {
            isAttacking = true;
            attackTimer = attackCoolDown;

            attackTrigger.enabled = true;
        }
        if(isAttacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                isAttacking = false;
                attackTrigger.enabled = false;
            }
        }
	}
}
