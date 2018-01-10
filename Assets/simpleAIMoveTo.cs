using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class simpleAIMoveTo : MonoBehaviour, KillableInterface {

    public float maxHealth = 10;
    public float damageOnTouch = 10.0f;
    public float ragdollThreshold = 1.0f;


    private float health;
    public bool onGround = false;

    private GameObject player;
    private NavMeshAgent agent;
    private Rigidbody body;
    private Material mat;
    



	// Use this for initialization
	void Start ()
    {
        health = maxHealth;

        player = FindObjectOfType<PlayerController>().gameObject;
        agent = GetComponent<NavMeshAgent>();
        body = GetComponent<Rigidbody>();
        mat = GetComponent<MeshRenderer>().material;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(body.velocity.magnitude > ragdollThreshold)
        {
            body.useGravity = true;
            agent.enabled = false;
            onGround = false;
        }
        else if(onGround)
        {
            body.useGravity = false;
            agent.enabled = true;
            agent.destination = player.transform.position;
        }

        if(transform.position.y < 0)
        {
            Kill();
        }

    }
    


    public void Damage(float dmg)
    {
        health = Mathf.Clamp(health - dmg, 0, maxHealth);

        mat.color = new Color(1, 1 * (health / maxHealth), 0);

        if (health == 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        KillableInterface ki = collision.gameObject.GetComponent<KillableInterface>();
        simpleAIMoveTo ai = collision.gameObject.GetComponent<simpleAIMoveTo>();
        if (ki != null && ai == null)
        {
            ki.Damage(damageOnTouch * Time.fixedDeltaTime);
        }
        if (collision.contacts[0].normal.y > 0)
        {
            onGround = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        KillableInterface ki = collision.gameObject.GetComponent<KillableInterface>();
        simpleAIMoveTo ai = collision.gameObject.GetComponent<simpleAIMoveTo>();
        if (ki != null && ai == null)
        {
            ki.Damage(damageOnTouch * Time.fixedDeltaTime);
        }
        if (collision.contacts[0].normal.y > 0)
        {
            onGround = true;
        }
    }

}
