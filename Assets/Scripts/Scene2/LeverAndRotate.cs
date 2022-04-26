using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAndRotate : MonoBehaviour
{
    public bool is2Rotate;

    private Transform player;
    public Transform lever;

    private bool isTriggered;
    public Transform rotation1;
    public Transform rotation2;
    private AudioScript audioScript;
    private bool isPlay;

    private void Start()
    {
        audioScript = FindObjectOfType<AudioScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isTriggered = true;
            player = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isTriggered = false;            
        }
    }

    private void Update()
    {
        
        if (isTriggered)
        {
            if (Mathf.Abs(rotation1.localRotation.z) < 0.382 || Mathf.Abs(rotation1.localRotation.z) > 0.924)
            {
                rotation1.GetChild(1).gameObject.layer = 7;
            }
            else
            {
                rotation1.GetChild(1).gameObject.layer = 0;
            }
            if (Mathf.Abs(rotation2.localRotation.z) < 0.382 || Mathf.Abs(rotation2.localRotation.z) > 0.924)
            {
                rotation2.GetChild(1).gameObject.layer = 7;
            }
            else
            {
                rotation2.GetChild(1).gameObject.layer = 0;
            }
            if (Input.GetKey(KeyCode.E))
            {
                player.GetComponent<PlayerController>().isStopMoving = true;
                player.GetComponent<PlayerController>().moveInput = 0;
                player.GetComponent<PlayerController>().enabled = false;
                player.GetComponent<Animator>().SetBool("isRunning", false);
                if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
                {
                    lever.rotation = Quaternion.Slerp(lever.rotation, Quaternion.Euler(Vector3.forward * 0f), 5f * Time.deltaTime);
                }
                else
                {
                    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                    {
                        if (!isPlay)
                        {
                            audioScript.SFXs[11].Play();
                            isPlay = true;
                        }
                        lever.rotation = Quaternion.Slerp(lever.rotation, Quaternion.Euler(Vector3.forward * 20f), 5f * Time.deltaTime);
                        if(is2Rotate)
                        {
                            rotation1.Rotate(Vector3.forward * 150 * Time.deltaTime);
                            rotation2.Rotate(Vector3.forward * -100 * Time.deltaTime);
                        }
                        else
                        {
                            rotation1.Rotate(Vector3.forward * -80 * Time.deltaTime);
                            rotation2.Rotate(Vector3.forward * -200 * Time.deltaTime);
                        }
                        
                    }
                    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                    {
                        if (!isPlay)
                        {
                            audioScript.SFXs[11].Play();
                            isPlay = true;
                        }
                        lever.transform.rotation = Quaternion.Slerp(lever.transform.rotation, Quaternion.Euler(Vector3.forward * -20f), 5f * Time.deltaTime);
                        if (is2Rotate)
                        {
                            rotation1.Rotate(Vector3.forward * -150 * Time.deltaTime);
                            rotation2.Rotate(Vector3.forward * 100 * Time.deltaTime);
                        }
                        else
                        {
                            rotation1.Rotate(Vector3.forward * 80 * Time.deltaTime);
                            rotation2.Rotate(Vector3.forward * 200 * Time.deltaTime);
                        }
                    }
                    if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.RightArrow))
                    {
                        lever.rotation = Quaternion.Slerp(lever.rotation, Quaternion.Euler(Vector3.forward * 0f), 5f * Time.deltaTime);
                        audioScript.SFXs[11].Stop();
                        isPlay = false;
                    }

                }

            }
            else
            {
                audioScript.SFXs[11].Stop();
                isPlay = false;
                lever.rotation = Quaternion.Slerp(lever.rotation, Quaternion.Euler(Vector3.forward * 0f), 5f * Time.deltaTime);
                player.GetComponent<PlayerController>().enabled = true;
                player.GetComponent<PlayerController>().isStopMoving = false;
            }
        }
    }
}
