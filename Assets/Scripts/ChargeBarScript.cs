using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChargeBarScript : MonoBehaviour
{
    public Image currentChargeUpBar;
    public GameObject chargeBar;

    Vector3 ChargeBarNeutralPosition;

    float currentChargePoint = 1f;
    float maxChargePoint = 100f;
    float shakeAmount = 0f;
    float chargeSpeed = 10f;
    public float barCost = 1000f;

    bool isCharging;
    bool canShoot;

    private void Awake()
    {
        //chargeBar = GetComponentInChildren<GameObject>();
    }

    void Start()
    {
        ChargeBarNeutralPosition = chargeBar.transform.localPosition;
    }

    void Update()
    {
        if (chargeBar)
        { 
            
            if(currentChargePoint >= maxChargePoint)
            {
                canShoot = false;
         
            }
            else
            {
                canShoot = true;
            }


            if (0 <= currentChargePoint)
            {
                ChargeBar(-chargeSpeed);
            }
            if (Input.GetMouseButtonDown(0) && canShoot == true)
            {             
                isCharging = true;
                
                ChargeBar(barCost);
                if (Input.GetMouseButtonUp(0))
                {
                    isCharging = false;
                }
            }
        }
    }

    void UpdateRangedChargeBar()
    {
        float ratio = currentChargePoint / maxChargePoint;
        Debug.Log(ratio);
        currentChargeUpBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    public void ChargeBar(float charge)
    {
        currentChargePoint += charge * Time.deltaTime;
        
        if(currentChargePoint >= maxChargePoint)
        {
            currentChargePoint = maxChargePoint;
        }
        UpdateRangedChargeBar();
    }

    public void Reset()
    {
        currentChargePoint = 1f;
    }

    public void Shake(float amount, float duration)
    {
        shakeAmount = amount;
        InvokeRepeating("BeginShake", 0, 0.01f);
        Invoke("StopShake", duration);
        chargeBar.transform.localPosition = Vector3.Lerp(chargeBar.transform.localPosition, ChargeBarNeutralPosition, Time.deltaTime);
    }

    void BeginShake()
    {
        if (shakeAmount > 0)
        {
            Vector3 camPos = chargeBar.transform.position;

            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetZ = Random.value * shakeAmount * 2 - shakeAmount;
            camPos.x += offsetX;
            camPos.y += offsetY;
            camPos.z += offsetZ;

            chargeBar.transform.position = camPos;
        }
    }

    void StopShake()
    {
        CancelInvoke("BeginShake");
    }
}
