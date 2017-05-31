using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject explosion;
    public float lifeTime = 2.0f;
    private float speed = 10.0f;

    private float shootTime;
    public bool isShootingLeft = false;

    private void InitObject()
    {
        shootTime = Time.time;
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position -= transform.right * speed * Time.deltaTime;

        if (Time.time >= shootTime + lifeTime)
        {
            PoolManager.Instance.ReleaseObjectFromPool(name, gameObject);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
