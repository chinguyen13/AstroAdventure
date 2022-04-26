using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Transform deathTransition;
    public Transform[] objects;
    public Vector2[] objPos;
    private AudioScript audioScript;
    private void Start()
    {
        audioScript = FindObjectOfType<AudioScript>();
        if (objects.Length > 0)
        {
            for (int i = 0 ; i < objects.Length; i++)
            {
                objPos[i] = new Vector2(objects[i].position.x, objects[i].position.y);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioScript.SFXs[8].Play();
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Transition());         
        }
    }

    IEnumerator Transition()
    {
        deathTransition.gameObject.SetActive(true);
        player.gameObject.GetComponent<PlayerController>().enabled = false;
        player.gameObject.GetComponent<Animator>().enabled = false;
        yield return new WaitForSeconds(0.7f);
        player.transform.position = respawnPoint.transform.position;
        player.transform.eulerAngles = new Vector3(0,0,0);
        if (objects.Length > 0)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].GetComponent<rockpull>().xPos = objPos[i].x;
                objects[i].position = new Vector3(objPos[i].x, objPos[i].y,objects[i].position.z);        
            }
        }
        yield return new WaitForSeconds(1.31f);
        deathTransition.gameObject.SetActive(false);
        player.gameObject.GetComponent<PlayerController>().enabled = true;
        player.gameObject.GetComponent<Animator>().enabled = true;
    }
}
