using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [Header("Movement Speed")]
    public float pSpeed = 5f;
    [Space(3)]
    [Header("Jump Height")]
    public float pJump = 15f;
    private bool grounded;
    private bool doubleJump;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask layerGround;

    Animator myAnimator;
    private Vector2 spawnPoint;
    private bool attack;

    private Rigidbody2D rb2d;

    Vector3 movement;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        spawnPoint = transform.position;
    }


    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, layerGround);
    }

    // Update is called once per frame
    void Update()
    {
        //Keyboard Movement
        if (Input.GetKey(KeyCode.D))
        {
            rb2d.velocity = new Vector2(pSpeed, rb2d.velocity.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb2d.velocity = new Vector2(-pSpeed, rb2d.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, pJump);
        }

        if (grounded)
            doubleJump = false;// False meaning i can do double jump

        if (Input.GetKeyDown(KeyCode.Space) && !grounded && !doubleJump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, pJump);
            doubleJump = true; //True meaning i cant
        }

        //Controller Movement
        if (Input.GetKey(KeyCode.Joystick1Button1) && grounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, pJump);
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && !grounded && !doubleJump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, pJump);
            doubleJump = true; //True meaning i cant
        }

        float moveHorizontal = Input.GetAxis("Horizontal");

        movement = new Vector3(moveHorizontal, 0f);

        movement = movement * pSpeed * Time.deltaTime;

        transform.position += movement;
    }


    public void Reset()
    {
        transform.position = spawnPoint;
    }
}