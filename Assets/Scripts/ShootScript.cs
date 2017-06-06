using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameManagerScript gMScript;
    public ChargeBarScript rangedChargeScript;

    public GameObject Projectile_Emitter;
    public GameObject Projectile;

    float sage_Projectile_Forward_Force = 300f;
    float sage_Current_Projectile_Size = 0f;
    float sage_Max_Projectile_Size = 1f;

    float ninja_Projectile_Forward_Force = 1000f;
    float ninja_Current_Projectile_Count = 0f;
    int ninja_Shurikens;
    float ShurikenFireRate = 0.5f;
    float ninja_Max_Projectile_Count = 3f;

    float warrior_Projectile_Forward_Force = 500f; // PROJECTILE IS AFFECTED BY 1.3X GRAVITY
    float warrior_Max_Projectile_Forward_Force = 1500f; // PROJECTILE IS AFFECTED BY 1.3X GRAVITY

    float windWalker_Projectile_Forward_Force = 1000f;
    float windWalker_Max_Projectile_Forward_Force = 2000f;

    float forceMultiplier = 1f;
    float charge = 0f;

	void Update ()
    {
        if(gMScript.WindWalkerActive() == true)
        WindWalkerShoot();

        if(gMScript.NinjaActive() == true)
        NinjaShoot();

        if(gMScript.WarriorActive() == true)
        WarriorShoot();

        if(gMScript.SageActive() == true)
        SageShoot();    
	}

    void ChargeUps()
    {
        if (gMScript.WindWalkerActive() == true)
        {
            if (forceMultiplier <= windWalker_Max_Projectile_Forward_Force)
            {
                forceMultiplier += windWalker_Projectile_Forward_Force * Time.deltaTime;
                charge = forceMultiplier / 20;
                rangedChargeScript.ChargeBar(charge);
            }
        }

        if (gMScript.NinjaActive() == true)
        {
            if (ninja_Current_Projectile_Count <= ninja_Max_Projectile_Count)
            {
                float ninjaModifier = 1f;
                ninja_Current_Projectile_Count += ninjaModifier * Time.deltaTime;
                charge = ninja_Current_Projectile_Count * 25;
                rangedChargeScript.ChargeBar(charge);
                if(ninja_Current_Projectile_Count < 1f)
                {
                    ninja_Shurikens = 0;
                }
                if(1f <= ninja_Current_Projectile_Count && ninja_Current_Projectile_Count < 2f)
                {
                    ninja_Shurikens = 1;
                }
                if(2f <= ninja_Current_Projectile_Count && ninja_Current_Projectile_Count < 3f)
                {
                    ninja_Shurikens = 2;
                }
                if(3f <= ninja_Current_Projectile_Count)
                {
                    ninja_Shurikens = 3;
                }
            }
        }

        if (gMScript.WarriorActive() == true)
        {
            if (forceMultiplier <= warrior_Max_Projectile_Forward_Force)
            {
                forceMultiplier += warrior_Projectile_Forward_Force * Time.deltaTime;
                charge = forceMultiplier / 17;
                rangedChargeScript.ChargeBar(charge);
            }
        }

        if (gMScript.SageActive() == true)
        {
            if (sage_Current_Projectile_Size <= sage_Max_Projectile_Size)
            {              
                float modifier = 0.4f;
                sage_Current_Projectile_Size += modifier * Time.deltaTime;
                charge = sage_Current_Projectile_Size * 80f;
                rangedChargeScript.ChargeBar(charge);
            }
            if(sage_Current_Projectile_Size >= sage_Max_Projectile_Size)
            {
                rangedChargeScript.Shake(0.01f,0.02f);
                Debug.Log("Shaking");
            }
        }
    }

    void WindWalkerShoot()
    {
        if (Input.GetMouseButton(1))
        {
            ChargeUps();

            if (Input.GetMouseButtonDown(0))
            {
                GameObject Temporary_Projectile_Handler;
                Temporary_Projectile_Handler = Instantiate(Projectile, Projectile_Emitter.transform.position, Projectile_Emitter.transform.rotation) as GameObject;

                Temporary_Projectile_Handler.transform.Rotate(Vector3.forward * 90); // Projectile spin feel

                Rigidbody Temporary_RigidBody;
                Temporary_RigidBody = Temporary_Projectile_Handler.GetComponent<Rigidbody>();

                Temporary_RigidBody.AddForce(transform.right * forceMultiplier);
                forceMultiplier = 1f;
                charge = 0f;

                rangedChargeScript.Reset();

                Destroy(Temporary_Projectile_Handler, 5f);
            }
        }
        else
        {
            forceMultiplier = 1f;
            rangedChargeScript.Reset();
        }
    }

    void WarriorShoot()
    {
        if (Input.GetMouseButton(1))
        {
            ChargeUps();
            if (Input.GetMouseButtonDown(0))
            {
                GameObject Temporary_Projectile_Handler;
                Temporary_Projectile_Handler = Instantiate(Projectile, Projectile_Emitter.transform.position, Projectile_Emitter.transform.rotation) as GameObject;

                Temporary_Projectile_Handler.transform.Rotate(Vector3.forward * 90); // Projectile spin feel

                Rigidbody Temporary_RigidBody;
                Temporary_RigidBody = Temporary_Projectile_Handler.GetComponent<Rigidbody>();

                Temporary_RigidBody.AddForce(transform.right * warrior_Projectile_Forward_Force);
                forceMultiplier = 1f;
                charge = 0f;

                rangedChargeScript.Reset();

                Destroy(Temporary_Projectile_Handler, 5f);
            }
        }
        else
        {
            forceMultiplier = 1f;
            rangedChargeScript.Reset();
        }
    }

    void NinjaShoot()
    {
        if (Input.GetMouseButton(1))
        {
            ChargeUps();
            if (Input.GetMouseButtonDown(0) && ninja_Shurikens != 0)
            {
                StartCoroutine(ShurikenBurst());
            }

        }
        else
        {
            rangedChargeScript.Reset();
            ninja_Shurikens = 0;
            ninja_Current_Projectile_Count = 0;
        }
    }

    IEnumerator ShurikenBurst()
    {
        for (int i = 0; i < ninja_Shurikens; i++)
        {
            GameObject Temporary_Projectile_Handler;
            Temporary_Projectile_Handler = Instantiate(Projectile, Projectile_Emitter.transform.position, Projectile_Emitter.transform.rotation) as GameObject;

            Temporary_Projectile_Handler.transform.Rotate(Vector3.forward * 90); // Projectile spin feel

            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Projectile_Handler.GetComponent<Rigidbody>();

            Temporary_RigidBody.AddForce(transform.right * ninja_Projectile_Forward_Force);

            Destroy(Temporary_Projectile_Handler, 5f);
            yield return new WaitForSeconds(ShurikenFireRate);
        }
        rangedChargeScript.Reset();
        ninja_Shurikens = 0;
        ninja_Current_Projectile_Count = 0;
    }

    void SageShoot()
    {       
        if (Input.GetMouseButton(1))
        {
            ChargeUps();
            if (Input.GetMouseButtonDown(0))
            {
                GameObject Temporary_Projectile_Handler;
                Temporary_Projectile_Handler = Instantiate(Projectile, Projectile_Emitter.transform.position, Projectile_Emitter.transform.rotation) as GameObject;

                Temporary_Projectile_Handler.transform.Rotate(Vector3.forward * 90);
                Temporary_Projectile_Handler.transform.localScale += new Vector3(sage_Current_Projectile_Size/1.5f, sage_Current_Projectile_Size/1.5f, sage_Current_Projectile_Size/1.5f);
                
                Rigidbody Temporary_RigidBody;
                Temporary_RigidBody = Temporary_Projectile_Handler.GetComponent<Rigidbody>();

                Temporary_RigidBody.AddForce(transform.right * sage_Projectile_Forward_Force);
                Debug.Log(Temporary_Projectile_Handler.transform.localScale);

                rangedChargeScript.Reset();
                sage_Current_Projectile_Size = 0f;

                Destroy(Temporary_Projectile_Handler, 5f);
            }
        }
        else
        {
            sage_Current_Projectile_Size = 0f;       
            rangedChargeScript.Reset();
        }
    }
}
