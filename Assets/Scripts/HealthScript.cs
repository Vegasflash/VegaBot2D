using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public Text healthRatioText;
    public Image currentHealthBar;
    public GameObject healthPool;
    public GameObject player;

    float currentHealthPoint = 150;
    float maxHealthPoint = 150;



    public void UpdateHealthPower()
    {
        float ratio = currentHealthPoint / maxHealthPoint;
        currentHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        healthRatioText.text = (ratio * 100).ToString("0") + "%";
    }

    public void DamageHealth(float damage)
    {
        currentHealthPoint -= damage;
        if(currentHealthPoint < 0 )
        {
            currentHealthPoint = 0;
            Debug.Log("DEAD");
        }
        UpdateHealthPower();
    }

    public void HealHealth(float heal)
    {
        currentHealthPoint += heal;
        if(currentHealthPoint > 100)
        {
            Debug.Log("Full Health");
            currentHealthPoint = 100;
        }
        UpdateHealthPower();
    }
}
