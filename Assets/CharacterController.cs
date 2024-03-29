using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer sprite;
    private Animator anim;
    private Vector3 startPos;
    private bool onGround;

    private float directionX = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        startPos = this.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        directionX = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(directionX * 6f, rb2d.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            
            StartCoroutine(JumpTime());
            rb2d.velocity = new Vector2(rb2d.velocity.x, 12f);
            
        }

        UpdateAnimationState();
    }

    IEnumerator JumpTime()
    {
        yield return new WaitForSeconds(1f);
    }
    /*
    private void OnCollisionEnter2D(Collision2D col)
    {
       if (col) { }
    }
    */
    private void UpdateAnimationState()
    {
        anim.SetFloat("Move.X", rb2d.velocity.x);
        anim.SetFloat("Move.Y", rb2d.velocity.y);
        

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)    
        {
            anim.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
        }


        /* anim.SetFloat("Move.x", rb2d.velocity.x);

        if (Input.GetKey(KeyCode.D)) 
        {
            anim.SetBool("Right.X", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("Right.X", false);
            Debug.Log("Left");
        }
        else
        {
           */
    }
    /*
     private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag == "light")
        {
             anim.SetBool("Death.R", true);
            this.gameObject.GetComponent<CharacterController>().enabled = !this.gameObject.GetComponent<CharacterController>().enabled;
            StartCoroutine("DeathPause");
            
            
        }
        
    }

    private void Die()
    {
        Respawn();
    }
    private void Respawn()
    {
        anim.SetFloat("Move.X", 0);
        rb2d.transform.position = startPos;
        this.gameObject.GetComponent<CharacterController>().enabled = this.gameObject.GetComponent<CharacterController>().enabled;
        anim.SetBool("Death.R", false);
    }
    IEnumerator DeathPause()
    {
        yield return new WaitForSeconds(3f);
        Die();
    } */

}




