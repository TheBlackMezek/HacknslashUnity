using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingObject : MonoBehaviour {

    public float damageOnTouch = 10.0f;



    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        KillableInterface ki = collision.gameObject.GetComponent<KillableInterface>();
        if (ki != null)
        {
            ki.Damage(damageOnTouch * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        KillableInterface ki = collision.gameObject.GetComponent<KillableInterface>();
        if (ki != null)
        {
            ki.Damage(damageOnTouch * Time.fixedDeltaTime);
        }
    }

}
