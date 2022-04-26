using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleDead : MonoBehaviour
{
    public Animator anim;
    public GameObject deadTrigger;
    private PlayerController player;
    public AIPatrol aiPatrol;
    private AudioScript audioScript;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        audioScript = FindObjectOfType<AudioScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            audioScript.SFXs[6].Play();
            anim.SetBool("isDead", true);
            deadTrigger.SetActive(false);
            anim.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
            anim.transform.localPosition += new Vector3(1, 0, 0);
            aiPatrol.mustPatrol = false;
            player.anim.SetTrigger("takeOff");
            player.jumpTimeCounter = player.jumpTime;
            player.rb.velocity = Vector2.up * player.jumpForce;
            if(Input.GetKey(KeyCode.Space))
            {
                player.isJumping = true;
            }
        }
    }

}
