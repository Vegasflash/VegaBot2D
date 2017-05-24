using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeTriggerScript : MonoBehaviour
{
    public int dmg = 20;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Enemy"))
        {
            Debug.Log("Do Damage");
            collider.SendMessageUpwards("DamageHealth", dmg);
        }
    }

}
