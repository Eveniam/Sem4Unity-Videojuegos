using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator ani;
    SpriteRenderer sr;

    /*readonly string ANIMATOR_STATE = "Estado";
    readonly int ANIMATOR_IDLE = 0;
    readonly int ANIMATOR_WALK = 1;
    readonly int ANIMATOR_RUN = 2;
    readonly int ANIMATOR_JUMP = 3;
    readonly int ANIMATOR_DEAD = 4;*/
    readonly int LEFT = -1;
    public float jumpForce = 10f;
    public float velocity = 10f;

    void Start()
    {
        Debug.Log("START");
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        ani.SetInteger("Estado", 0);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocity, rb.velocity.y);
            sr.flipX = 1 == LEFT;
            ani.SetInteger("Estado", 1);
        }

        if (Input.GetKey(KeyCode.LeftArrow)){
            rb.velocity = new Vector2(-velocity, rb.velocity.y);
            sr.flipX = -1 == LEFT;
            ani.SetInteger("Estado", 1);
            
        }

        if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.X)){ 
            rb.velocity = new Vector2(10, rb.velocity.y);
            sr.flipX = 1 == LEFT;
            ani.SetInteger("Estado", 2);
        }
        if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.X)){
            rb.velocity = new Vector2(-10, rb.velocity.y);
            sr.flipX = -1 == LEFT;
            ani.SetInteger("Estado", 2);
        }
        if(Input.GetKeyUp(KeyCode.Space)){

            rb.AddForce(transform.up * jumpForce);
            ani.SetInteger("Estado", 3);
        }
    }

}
