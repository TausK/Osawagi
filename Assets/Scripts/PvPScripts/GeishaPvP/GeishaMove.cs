using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeishaPvP
{
    public class GeishaMove : MonoBehaviour
    {
        public float speed = 4f;
        public float jumpForce = 10f;
        private bool attackMotion;

        public float rayDist = 0.5f;
        public bool grounded;
        public bool doubleJump;
        public Transform groundCheck;
        public LayerMask groundLayer;
        private Vector2 spawnpoint;

        #region KeyCodes
        public KeyCode left;
        public KeyCode right;
        public KeyCode jump;
        public KeyCode attack;
        #endregion

        private Rigidbody2D rb;
        private Animator anim;



        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            spawnpoint = transform.position;
        }

        // Update is called once per frame
        void Update()
        {

            Move();
            AttackInput();
            

        }

        void FixedUpdate()
        {
            PlayerGrounded();
            HandleAttack();
            ResetAttack();
        }


        void Move()
        {
            #region Move left & right
            if (Input.GetKey(left))
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                
                if (Input.GetKey(left))
                {
                    anim.SetBool("Move", true);
                }
                else
                {
                    anim.SetBool("Move", false);
                }
            }
            else if (Input.GetKey(right))
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                if (Input.GetKey(right))
                {
                    anim.SetBool("Move", true);
                }
                else
                {
                    anim.SetBool("Move", false);
                }
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                anim.SetBool("Move", false);
            }

            if (rb.velocity.x < 0)
            {
                transform.localScale = new Vector2(-1, 1);
            }
            else if (rb.velocity.x > 0)
            {
                transform.localScale = new Vector2(1, 1);
            }

            #endregion

            #region Jump Keyboard

            if (Input.GetKeyDown(jump) && grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }

            if (grounded)
                doubleJump = false;
            {
                if (Input.GetKeyDown(jump) && !grounded && !doubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    doubleJump = true;
                }
            }
            anim.SetBool("Grounded", grounded);
            #endregion

        }
        void OnDrawGizmos()
        {
            Ray ray = new Ray(groundCheck.position, Vector2.down);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(ray.origin, ray.origin + ray.direction * rayDist);

        }
        void PlayerGrounded()
        {
            Ray ray = new Ray(groundCheck.position, Vector2.down);
            RaycastHit2D hit2D = Physics2D.Raycast(ray.origin, ray.direction, rayDist, groundLayer);
            grounded = hit2D.collider != null;
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            //If the player collides with the moving platform then...
            if (col.transform.tag == "MovingPlatform")
            {
                //Allow the moving platform to be the parent of the collider
                transform.SetParent(col.transform);
            }
        }

        void OnCollisionExit2D(Collision2D col)
        {
            //If the player exits the moving platform then...
            if (col.transform.tag == "MovingPlatform")
            {
                //Remove the set parent 
                transform.SetParent(null);
            }
        }

        void HandleAttack() //Set trigger for attack movement
        {
            if (attackMotion)
            {
                anim.SetTrigger("Attack");
            }
        }

        void AttackInput()
        {
            if (Input.GetKeyDown(attack))
            {
                attackMotion = true;
            }
        }

        void ResetAttack()
        {
            attackMotion = false;
        }



        public void Reset()
        {
            transform.position = spawnpoint;
            //Reset player velocity when respawned
            rb.velocity = new Vector2(0, 0);
        }
    }
}