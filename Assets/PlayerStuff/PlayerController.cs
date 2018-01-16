using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour, KillableInterface {


    public float maxHealth = 100.0f;

    public float moveSpeed = 10.0f;
    public float fallAccel = 10.0f;
    public float jumpImpulse = 30.0f;
    public float rotationSpeed = 2.0f;
    public float animationSpeed = 0.5f;

    public LayerMask playerMask;
    public Animator animator;

    private float health;

    private CharacterController controller;
    private Transform camTrans;
    private RectTransform healthPanelTrans;
    private RectTransform hurtPanelTrans;
    //private float fallSpeed = 0;
    private Vector3 velocity = Vector3.zero;

    private bool spaceKey = false;
    private float verticalAxis = 0;
    private float horizontalAxis = 0;

    



    private void Start()
    {
        controller = GetComponent<CharacterController>();
        healthPanelTrans = transform.Find("HealthCanvas").Find("HealthPanel").GetComponent<RectTransform>();
        hurtPanelTrans   = transform.Find("HealthCanvas").Find("HurtPanel").GetComponent<RectTransform>();
        health = maxHealth;
        
        Cursor.lockState = CursorLockMode.Locked;
        camTrans = transform.Find("Main Camera");
    }
    
    private void Update () {

        transform.Rotate(Quaternion.Euler(0,
                                          Input.GetAxis("Mouse X") * rotationSpeed,
                                          0).eulerAngles);

        spaceKey = Input.GetKey(KeyCode.Space);
        verticalAxis   = Input.GetAxis("Vertical");
        horizontalAxis = Input.GetAxis("Horizontal");

        if(controller.velocity.magnitude > 0)
        {
            animator.SetBool("IsWalking", true);
            animator.SetFloat("WalkSpeed", controller.velocity.magnitude * animationSpeed);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    private void FixedUpdate()
    {
        velocity.x = 0;
        velocity.z = 0;
        velocity += transform.forward * moveSpeed * verticalAxis;
        velocity += transform.right   * moveSpeed * horizontalAxis;

        
        if (!controller.isGrounded)
        {
            velocity.y -= fallAccel * Time.fixedDeltaTime;
        }
        else
        {
            velocity.y = 0;
            velocity.y -= fallAccel * Time.fixedDeltaTime;
        }

        if (spaceKey && controller.isGrounded)
        {
            velocity.y += jumpImpulse;
        }


        controller.Move(velocity * Time.fixedDeltaTime);

        if(transform.position.y < 0)
        {
            Kill();
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.normal.y < 0 && velocity.y > 0)
        {
            velocity.y = 0;
        }

        if(hit.gameObject.GetComponent<DamagingObject>())
        {
            Damage(hit.gameObject.GetComponent<DamagingObject>().damageOnTouch * Time.fixedDeltaTime);
        }
    }



    public void Damage(float dmg)
    {
        health = Mathf.Clamp(health - dmg, 0, maxHealth);
        healthPanelTrans.localScale =
                                    new Vector3(hurtPanelTrans.localScale.x * (health / maxHealth),
                                                healthPanelTrans.localScale.y,
                                                1);
        if(health == 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        health = 0;
        Damage(-maxHealth);
        Cursor.lockState = CursorLockMode.None;
        StartCoroutine(AsynchronousLoadScene());
        //transform.position = new Vector3(0, 5, 0);
    }

    IEnumerator AsynchronousLoadScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Scenes/MainMenu");
        Debug.Log("Beginning load");
        while (!asyncLoad.isDone)
        {
            Debug.Log("Loading...");
            yield return null;
        }
    }

}
