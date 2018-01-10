using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingObject : MonoBehaviour {

    public float damageOnTouch = 10.0f;



    protected void OnCollisionEnter(Collision collision)
    {
        KillableInterface ki = collision.gameObject.GetComponent<KillableInterface>();
        if (ki != null)
        {
            ki.Damage(damageOnTouch * Time.fixedDeltaTime);
        }
    }

    protected void OnCollisionStay(Collision collision)
    {
        KillableInterface ki = collision.gameObject.GetComponent<KillableInterface>();
        if (ki != null)
        {
            ki.Damage(damageOnTouch * Time.fixedDeltaTime);
        }
    }

}
