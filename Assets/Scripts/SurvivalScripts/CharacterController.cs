using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Character Movement")]
    public float speed;
    [Space(5)]
    [Header("Character Jump")]
    public float jumpHeight;
    private bool grounded;
    [Space(3)]
    public Transform groundCheck;
    [Space(3)]
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool doubleJump;

    private Rigidbody2D rb2b;

    private Vector2 spawnPoint;

    Animator myAnimator;
    private bool attack;

    // Use this for initialization
    void Start()
    {
        rb2b = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        spawnPoint = transform.position;
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

    }
    // Update is called once per frame
    void Update()
    {
        #region Movement
        if (Input.GetKey(KeyCode.D))
        {
            rb2b.velocity = new Vector2(speed, rb2b.velocity.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb2b.velocity = new Vector2(-speed, rb2b.velocity.y);
        }
        #endregion

        #region Jump
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb2b.velocity = new Vector2(rb2b.velocity.y, jumpHeight);
        }

        if (grounded) // If the character is on platform, it can perform double jump
            doubleJump = false;

        if (Input.GetKeyDown(KeyCode.Space) && !doubleJump && !grounded) // If character is not on platform after jump, double jump will be deactivated till on platform??
        {
            rb2b.velocity = new Vector2(rb2b.velocity.x, jumpHeight);
            doubleJump = true;
        }
        #endregion


    }

    public void Reset()
    {
        transform.position = spawnPoint;
    }



}
