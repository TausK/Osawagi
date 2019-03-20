using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    [Header("Movement Speeds")]
    public float pSpeed = 50.0f;
    #region raydistance
    public Transform origin;
    public float rayDistance = 1f;
    #endregion
    [Space(5)]
    [Header("Jump")]
    public float pJump = 150.0f;
    public bool grounded;
    private Vector3 spawnPoint;

    private Rigidbody2D rb2d;
    #endregion

    #region Unity Functions
    void OnDrawGizmos() //Showing raycast
    {
        if (origin != null)
        {
            Gizmos.DrawLine(origin.position, origin.position + Vector3.down * rayDistance);
        }
    }
    // Use this for initialization
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
       
    }
    void FixedUpdate() //Physics
    {
        CheckGround();
    }
    // Update is called once per frame
    void Update() 
    {
        Movement();
    }
    #endregion

    #region Custom Functions
    void Movement()
    {
        float moveH = Input.GetAxis("Horizontal"); // Horizontal Direction (Move left and right)
        float moveV = Input.GetAxis("Vertical"); // Vertical Direction (Jump)

        rb2d.AddForce(Vector3.right * pSpeed * moveH);// Adding momentum to player

        if (Input.GetKeyDown("Space") && grounded)
        {
            rb2d.AddForce(new Vector2(0, moveV), ForceMode2D.Impulse);
        }
    }
    void CheckGround() //Setting raycast
    {
        // Create a ray that starts from the center of transform and goes down
        Ray ray = new Ray(origin.position, Vector3.down);
        // Perform Raycast using ray and specified distance
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, rayDistance);
        // If the Raycast hit a collider
        if (hit.collider != null) // AND the collider hit is not myself
        {
            // If something is hit, set grounded back to true (for jumping)
            grounded = true;
            print(grounded);
        }
        else
        {
            grounded = false;
        }
    }
    #endregion
}
