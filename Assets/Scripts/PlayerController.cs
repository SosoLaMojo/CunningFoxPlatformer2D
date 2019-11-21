using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    private Animator Animator;

    [SerializeField]
    private int egg = 0;

    private Vector2 velocity; 
    private Rigidbody2D rigidBody;

    [SerializeField]
    private float maxSpeed, maxSpeedJump, radiusCircle;

    [SerializeField]
    private GameObject groundCheck;

    [SerializeField]
    private LayerMask layer;

    //private Vector3 startPosition;

    private void Start()
    {
       // startPosition = transform.position;
        velocity = Vector2.zero;
        rigidBody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }
    private void Update()
    {
        // get value in the axes x and y
        float x = Input.GetAxisRaw("Horizontal");

        Animator.SetFloat("Speed", Mathf.Abs(x));

        if(x == -1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(x == 1)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        float y = 0;
        
        if(Input.GetButtonDown("Jump"))
        {
            y = 1;
        }

        // get velocity
        Vector2 _velocity = new Vector2 (x, y);

        // apply velocity
        RunAndJump(_velocity);

        //if (transform.position.y <= 13.5f)
        //{
        //    respawn();
        //}
    }

    void FixedUpdate()
    {
        PerformRunAndJump();
    }

    public void AddEgg(int value)
    {
        egg += value;
    }

    //public void respawn()
    //{
    //    transform.position = startPosition;
    //}

    public void RunAndJump(Vector2 _velocity)
    {
        velocity = _velocity;
    }

    private void PerformRunAndJump()
    {
        bool _grounded = Physics2D.OverlapBox(groundCheck.transform.position, new Vector3(0.32f, 0.06f, 0), layer);
        bool isGrounded = _grounded && Mathf.Abs(rigidBody.velocity.y) <= 0.01f;

        if (isGrounded)
        {
            rigidBody.AddForce(new Vector2(0f, velocity.y) * Time.deltaTime * maxSpeedJump, ForceMode2D.Impulse);
        }
        rigidBody.velocity = new Vector2(velocity.x * maxSpeed * Time.deltaTime, rigidBody.velocity.y);
        Animator.SetBool("IsJumping", !isGrounded);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(groundCheck.transform.position, new Vector3 (0.32f,0.06f,0));
    }
}
