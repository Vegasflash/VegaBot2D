using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    private Vector3 velocity;

    float smoothTimeY = 0.1f;
    float smoothTimeX = 0.1f;
    float shakeAmount = 0f;

    public GameObject target;
    public GameObject currentCam;

    Vector3 offset;
    Vector3 CamNeutralPosition;

    void Start()
    {
        CamNeutralPosition = currentCam.transform.localPosition;
    }

	void LateUpdate ()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, target.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, target.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);
    }

    public void Shake(float amount, float duration)
    {
        shakeAmount = amount;
        InvokeRepeating("BeginShake", 0, 0.01f);
        Invoke("StopShake", duration);
        currentCam.transform.localPosition = Vector3.Lerp(currentCam.transform.localPosition, CamNeutralPosition, Time.deltaTime);
    }

    void BeginShake()
    {
        if (shakeAmount > 0)
        {
            Vector3 camPos = currentCam.transform.position;

            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetZ = Random.value * shakeAmount * 2 - shakeAmount;
            camPos.x += offsetX;
            camPos.y += offsetY;
            camPos.z += offsetZ;

            currentCam.transform.position = camPos;
        }
    }

    void StopShake()
    {
        CancelInvoke("BeginShake");
    }
}
