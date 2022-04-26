using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headPos : MonoBehaviour
{
    private PlayerController player;
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            player.isJumping = false;
        }
    }
}
