using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDuplicator : MonoBehaviour
{
    float offset = 0.0f;
	// Use this for initialization
	void Start ()
    {
        
		for(int i = 0; i < 5; i++)
        {
            Instantiate(gameObject, transform.right *= 0.64f, Quaternion.identity);         
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
