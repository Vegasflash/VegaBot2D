using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapFloorScript : MonoBehaviour
{
    public HealthScript healthScript;

    bool isDamaging;
    float damage = 10f;

    void Start()
    {
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "WindWalker")
        {           
            Debug.Log("Dealing damage");
            healthScript.DamageHealth(damage);
        }
        if (collider.gameObject.tag == "Warrior")
        {
            Debug.Log("Dealing damage");
            healthScript.DamageHealth(damage);
        }
        if (collider.gameObject.tag == "Ninja")
        {
            Debug.Log("Dealing damage");
            healthScript.DamageHealth(damage);
        }
        if (collider.gameObject.tag == "Sage")
        {

            Debug.Log("Dealing damage");
            healthScript.DamageHealth(damage);
        }
    }
}
