using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeGrabScript : MonoBehaviour
{
    public GameObject receiver;
    public GameObject WindWalker;
    public GameObject Warrior;
    public GameObject Ninja;
    public GameObject Sage;

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.tag);
        if (collider.gameObject.tag == "WindWalker")
        {
            Debug.Log("In Range");
            if (Input.GetKey("space"))
            {
                Debug.Log("Grabbed on");
                WindWalker.transform.position = receiver.transform.position;
            }
        }
    }
}
