using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(DestroyObject());
	}
    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(.3f);
        Destroy(gameObject);
    }
	
}
