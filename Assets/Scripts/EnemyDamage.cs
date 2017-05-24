using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public HealthScript healthScript;
    public EnemyHealth enemyHealth;

    public GameObject windWalker;
    public GameObject sage;
    public GameObject warrior;
    public GameObject ninja;

    float enemyDmg = 5f;
    float rangedPlayerDamage = 10f;

    void Start()
    {
        if(ninja.activeInHierarchy)
        {
            healthScript = ninja.GetComponent<HealthScript>();
        }
        if (sage.activeInHierarchy)
        {
            healthScript = sage.GetComponent<HealthScript>();
        }
        if (warrior.activeInHierarchy)
        {
            healthScript = warrior.GetComponent<HealthScript>();
        }
        if (windWalker.activeInHierarchy)
        {
            healthScript = windWalker.GetComponent<HealthScript>();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "WindWalker")
        {
            
            healthScript.DamageHealth(enemyDmg);
        }
        if (collider.gameObject.tag == "Sage")
        {
            healthScript.DamageHealth(enemyDmg);
        }
        if (collider.gameObject.tag == "Warrior")
        {
            healthScript.DamageHealth(enemyDmg);
        }
        if (collider.gameObject.tag == "Ninja")
        {
            healthScript.DamageHealth(enemyDmg);
        }

        if (collider.gameObject.tag == "Projectile")
        {
            enemyHealth.DamageHealth(rangedPlayerDamage);
            Destroy(collider.gameObject);
        }
        
    }
}


