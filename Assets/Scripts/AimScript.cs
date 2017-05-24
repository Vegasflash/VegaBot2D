using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
    float smoothness = 100f;

    public bool isAiming;

    Quaternion initialRotation;

	void Update ()
    {
        isAiming = false;
               

        if (Input.GetMouseButton(1))
        {
            isAiming = true;
            transform.Rotate(0, 0, Input.GetAxis("Mouse Y") * smoothness * Time.deltaTime);
        }

        if (isAiming == false)
        {
            transform.rotation = initialRotation;

        }


	}
}
