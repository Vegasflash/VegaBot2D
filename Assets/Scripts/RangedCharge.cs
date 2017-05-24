using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RangedCharge : MonoBehaviour
{
    public Image currentChargeUpBar;
    public GameObject chargeBar;

    Vector3 ChargeBarNeutralPosition;

    float currentChargePoint = 1f;
    float maxChargePoint = 100f;
    float shakeAmount = 0f;

    bool isCharging;
     
    void UpdateRangedChargeBar()
    {
        float ratio = currentChargePoint / maxChargePoint;
        currentChargeUpBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    public void ChargeBar(float charge)
    {
        currentChargePoint += charge * Time.deltaTime;
        if(currentChargePoint == maxChargePoint)
        {
            
        }
        UpdateRangedChargeBar();
    }

    public void Reset()
    {
        currentChargePoint = 1f;
    }

    void Start()
    {
        ChargeBarNeutralPosition = chargeBar.transform.localPosition;
    }

    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            isCharging = true;
            chargeBar.SetActive(true);
            if(Input.GetMouseButtonDown(0))
            {
                isCharging = false;
                currentChargePoint = 1f;
            }
        }
        if (!Input.GetMouseButton(1))
        {
            chargeBar.SetActive(false);            
        }             
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
