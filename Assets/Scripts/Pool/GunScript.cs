using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Transform emitter;
    public GameObject bulletPrefab;
    public GameObject gun;
    public Projectile projectile;


    // Use this for initialization
    void Start ()
    {
        PoolDescription pool = new PoolDescription();
        pool.name = bulletPrefab.name;
        pool.category = "Ammo";
        pool.masterPrefab = bulletPrefab;
        pool.size = 100;

        pool.allowRuntimeCreation = true;

        PoolManager.Instance.AddPool(pool);

	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bulletGo = PoolManager.Instance.GetObjectFromPool(bulletPrefab.name, true);
            bulletGo.transform.position = emitter.position;
            bulletGo.transform.rotation = emitter.rotation;
        }
	}

    public void GunShift(int direction)
    {
        if(direction == 1)
        {
            gun.transform.localRotation = Quaternion.Euler(0, 180, 0);
            projectile.isShootingLeft = false;
        }
        if(direction == 2)
        {
            gun.transform.localRotation = Quaternion.Euler(0, 0, 0);
            projectile.isShootingLeft = true;
        }
    }
}
