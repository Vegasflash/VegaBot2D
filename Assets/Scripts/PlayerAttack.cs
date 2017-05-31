using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private bool isAttacking = false;

    private float attackTimer = 0f;
    private float attackCoolDown = 0.3f;

    public GameObject attackTrigger;

    private Animator anime;
	
    void Awake()
    {
        attackTrigger.SetActive(false);
    }
	void Update ()
    {
		if(Input.GetKeyDown("f") && !isAttacking)
        {
            isAttacking = true;
            attackTimer = attackCoolDown;

            attackTrigger.SetActive(true);
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
                attackTrigger.SetActive(false);
            }
        }
	}
}
