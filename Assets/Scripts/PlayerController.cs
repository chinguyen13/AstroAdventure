using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    [HideInInspector]
    public float moveInput;

    public bool isGrounded;
    public Transform feetPos;
    public float checkRadius;

    public LayerMask GroundKind;

    [HideInInspector]
    public float jumpTimeCounter;
    public float jumpTime;
    [HideInInspector]
    public bool isJumping;
    [HideInInspector]
    public bool isStopMoving = false;
    [HideInInspector]
    public Animator anim;
    private AudioScript audioScript;
    private bool checkIfPlay;
    private bool isJump;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioScript = FindObjectOfType<AudioScript>();
    }

    private void FixedUpdate() {
        if (!isStopMoving)
        {
            moveInput = Input.GetAxisRaw("Horizontal");   
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isGrounded)
        {
            if (collision.gameObject.tag == "Ground")
            {
                if (isJump)
                {
                    audioScript.SFXs[5].Play();
                }
            }
            else if (collision.gameObject.tag == "Rock")
            {
                if (isJump)
                {
                    audioScript.SFXs[5].Play();
                }
            }
            isJump = false;
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(isGrounded)
        {
            if (collision.gameObject.tag == "Ground")
            {

                if (moveInput != 0 && !checkIfPlay)
                {
                    audioScript.SFXs[2].Stop();
                    audioScript.SFXs[1].PlayDelayed(0.15f);
                    checkIfPlay = true;
                }
                else if (moveInput == 0)
                {
                    if (checkIfPlay)
                    {
                        audioScript.SFXs[1].Stop();
                        checkIfPlay = false;
                    }
                }
            }
            else if (collision.gameObject.tag == "Rock")
            {
                if (moveInput != 0 && !checkIfPlay)
                {
                    audioScript.SFXs[1].Stop();
                    audioScript.SFXs[2].PlayDelayed(0.15f);
                    checkIfPlay = true;
                }
                else if (moveInput == 0)
                {
                    if(checkIfPlay)
                    {
                        audioScript.SFXs[2].Stop();
                        checkIfPlay = false;
                    }

                }
            }
        }
    }

    private void Update() {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, GroundKind);

        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            audioScript.SFXs[3].Play();
            anim.SetTrigger("takeOff");
            isJumping = true;
            isJump = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }


        if(isGrounded)
        {
            anim.SetBool("isJumping", false);
        }else
        {
            audioScript.SFXs[2].Stop();
            audioScript.SFXs[1].Stop();
            checkIfPlay = false;
            anim.SetBool("isJumping", true);
        }

        
        if(Input.GetKey(KeyCode.Space) && isJumping)
        {
            if(jumpTimeCounter >0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }else
            {
                isJumping = false;
            }
            
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        if(moveInput == 0 || isStopMoving)
        {
            anim.SetBool("isRunning", false);
        }else
        {
            anim.SetBool("isRunning", true);
        }

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1.2f,1.2f,1f);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1.2f, 1.2f, 1f);
        }

    }
}
