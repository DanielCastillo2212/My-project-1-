using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sr;
    // Start is called before the first frame update

    private int currentAnimation = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        currentAnimation = 1;
        var velocityY = rb.velocity.y;

        rb.velocity = new Vector2(0, velocityY);

        //Run
        if(Input.GetKey(KeyCode.RightArrow)){
            currentAnimation = 2;
            rb.velocity = new Vector2(5, velocityY);
            sr.flipX = false;
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            currentAnimation = 2;
            rb.velocity = new Vector2(-5, velocityY);
            sr.flipX = true;
        }
        //Slide
        if(Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow)){
            currentAnimation = 3;
            rb.velocity = new Vector2(-5, velocityY);
            sr.flipX = true;
        }
        if(Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow)){
            currentAnimation = 3;
            rb.velocity = new Vector2(5, velocityY);
            sr.flipX = false;
        }
        //RunShoot
        if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.A)){
            currentAnimation = 4;
            rb.velocity = new Vector2(-5, velocityY);
            sr.flipX = true;
        }
        if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.A)){
            currentAnimation = 4;
            rb.velocity = new Vector2(5, velocityY);
            sr.flipX = false;
        }
        //Shoot
        if(Input.GetKey(KeyCode.D)){
            currentAnimation = 5;
            //rb.velocity = new Vector2(5, velocityY);
            sr.flipX = false;
        }
        if(Input.GetKey(KeyCode.S)){
            currentAnimation = 5;
            //rb.velocity = new Vector2(5, velocityY);
            sr.flipX = true;
        }
        //Melee
        if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.W)){
            currentAnimation = 6;
            rb.velocity = new Vector2(-5, velocityY);
            sr.flipX = true;
        }
        if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.W)){
            currentAnimation = 6;
            rb.velocity = new Vector2(5, velocityY);
            sr.flipX = false;
        }
        //Dead
        if(Input.GetKey(KeyCode.Q)){
            currentAnimation = 7;
        }

        animator.SetInteger("Estado", currentAnimation);
    }
}
