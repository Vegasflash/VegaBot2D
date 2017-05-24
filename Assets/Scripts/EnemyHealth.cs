using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Image currentHealthBar;
    public GameObject healthPool;
    public GameObject enemy;

    float currentHealthPoint = 150;
    float maxHealthPoint = 150;

    public void UpdateHealthPower()
    {   
        float ratio = currentHealthPoint / maxHealthPoint;
        currentHealthBar.rectTransform.localScale = new Vector3(ratio*0.04f, 0.005f, 0);   
        if(currentHealthPoint == 0)
        {
            Death();
        }     
    }

    void Death()
    {
        Destroy(enemy);
    }

    public void DamageHealth(float damage)
    {
        healthPool.SetActive(true);
        currentHealthPoint -= damage;
        if (currentHealthPoint < 0)
        {
            currentHealthPoint = 0;
            Debug.Log("DEAD");
        }
        UpdateHealthPower();
    }
}
