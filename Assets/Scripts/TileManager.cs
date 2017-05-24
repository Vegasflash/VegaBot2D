using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    // Use this for initialization

    public GameObject cyber_tile;
    float offset = 1.28f;

	void Start ()
    {
        for(int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 10; j++)
            {
                Vector3 newPos = new Vector3( i * offset, j * offset, 0);
                Instantiate(cyber_tile, newPos ,Quaternion.identity);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
