using UnityEngine;

public class LeverAndElevator : MonoBehaviour
{
    public bool isHorizontal;
    public float smallLimit;
    public float bigLimit;

    public Transform lever;
    public Transform elevator;

    private bool isTriggered;
    private GameObject player;
    private bool isSmallLimit;
    private bool isBigLimit;
    public bool isPlayer;
    public bool isRock;
    public Transform rock;
    public GameObject rockTrigger;
    private AudioScript audioScript;
    private bool isPlay;

    private void Start()
    {
        audioScript = FindObjectOfType<AudioScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isTriggered = true;
            player = collision.gameObject;
            if (isRock)
                rock.gameObject.GetComponent<rockpull>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" )
        {
            isTriggered = false;
            if(isRock)
            {
                rock.gameObject.GetComponent<rockpull>().xPos = rock.position.x;
                rock.GetComponent<rockpull>().enabled = true;
            }
        }
    }

    private void Update()
    {
        if (!isHorizontal)
        {
            if (elevator.position.y < smallLimit)
            {
                isSmallLimit = true;
                elevator.position = new Vector3(elevator.position.x, smallLimit, elevator.position.z);
            }               
            else if(elevator.position.y > bigLimit)
            {
                isBigLimit = true;
                elevator.position = new Vector3(elevator.position.x, bigLimit, elevator.position.z);
            }

        }
        else
        {
            if (elevator.position.x < smallLimit)
            {
                isSmallLimit = true;
                elevator.position = new Vector3(smallLimit, elevator.position.y, elevator.position.z);
            }

            else if (elevator.position.x > bigLimit)
            {
                isBigLimit = true;
                elevator.position = new Vector3(bigLimit, elevator.position.y, elevator.position.z);
            }
        }
        if (isTriggered)
        {
            if(Input.GetKey(KeyCode.E))
            {
                player.GetComponent<PlayerController>().isStopMoving = true;
                player.GetComponent<PlayerController>().moveInput = 0;
                player.GetComponent<PlayerController>().enabled = false;
                player.GetComponent<Animator>().SetBool("isRunning", false);
                if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))&& (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
                {
                    lever.rotation = Quaternion.Slerp(lever.rotation, Quaternion.Euler(Vector3.forward * 0f), 5f * Time.deltaTime);
                    audioScript.SFXs[11].Stop();
                    isPlay = false;
                }
                else
                {
                    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                    {
                        if(!isPlay)
                        {
                            audioScript.SFXs[11].Play();
                            isPlay = true;
                        }

                        lever.rotation = Quaternion.Slerp(lever.rotation, Quaternion.Euler(Vector3.forward * 20f), 5f * Time.deltaTime);
                        if (!isHorizontal)
                        {
                            if (elevator.position.y >= smallLimit && elevator.position.y <= bigLimit)
                            {
                                elevator.Translate(Vector3.down * 2f * Time.deltaTime, Space.Self);
                                if (!isSmallLimit)
                                {
                                    if(isPlayer)
                                        player.transform.Translate(Vector3.down * 2f * Time.deltaTime, Space.Self);
                                    if (isRock && rockTrigger.GetComponent<RockAndElevator>().isReach)
                                    {
                                        rock.transform.Translate(Vector3.down * 2f * Time.deltaTime, Space.Self);
                                    }
                                }
                                    
                               
                            }

                        }
                        else
                        {
                            if (elevator.position.x >= smallLimit && elevator.position.x <= bigLimit)
                            {
                                elevator.Translate(Vector3.left * 2f * Time.deltaTime, Space.Self);
                                if (!isSmallLimit)
                                {
                                    if (isPlayer)
                                        player.transform.Translate(Vector3.left * 2f * Time.deltaTime, Space.Self);
                                    if (isRock && rockTrigger.GetComponent<RockAndElevator>().isReach)
                                    {
                                        rock.transform.Translate(Vector3.left * 2f * Time.deltaTime, Space.Self);
                                    }
                                }
                            }

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
                        if (!isHorizontal)
                        {
                            if (elevator.position.y >= smallLimit && elevator.position.y <= bigLimit)
                            {
                                elevator.Translate(Vector3.up * 2f * Time.deltaTime, Space.Self);
                                if (!isBigLimit)
                                {
                                    if (isPlayer)
                                        player.transform.Translate(Vector3.up * 2f * Time.deltaTime, Space.Self);
                                    if (isRock && rockTrigger.GetComponent<RockAndElevator>().isReach)
                                    {
                                        rock.transform.Translate(Vector3.up * 2f * Time.deltaTime, Space.Self);
                                    }
                                }
                            }

                        }
                        else
                        {
                            if (elevator.position.x >= smallLimit && elevator.position.x <= bigLimit)
                            {
                                elevator.Translate(Vector3.right * 2f * Time.deltaTime, Space.Self);
                                if (!isBigLimit)
                                {
                                    if (isPlayer)
                                        player.transform.Translate(Vector3.right * 2f * Time.deltaTime, Space.Self);
                                    if (isRock && rockTrigger.GetComponent<RockAndElevator>().isReach)
                                    {
                                        rock.transform.Translate(Vector3.right * 2f * Time.deltaTime, Space.Self);
                                    }
                                }
                            }

                        }
                    }
                    if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftArrow))
                    {
                        isSmallLimit = false;
                        lever.rotation = Quaternion.Slerp(lever.rotation, Quaternion.Euler(Vector3.forward * 0f), 5f * Time.deltaTime);
                    }
                    if(!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.RightArrow))
                    {
                        isBigLimit = false;
                        lever.rotation = Quaternion.Slerp(lever.rotation, Quaternion.Euler(Vector3.forward * 0f), 5f * Time.deltaTime);
                    }
                    if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.RightArrow))
                    {
                        audioScript.SFXs[11].Stop();
                        isPlay = false;
                    }
                }
                
            }
            else
            {
                audioScript.SFXs[11].Stop();
                isPlay = false;
                if (isRock)
                    rock.GetComponent<rockpull>().enabled = false;
                lever.rotation = Quaternion.Slerp(lever.rotation, Quaternion.Euler(Vector3.forward * 0f), 5f * Time.deltaTime);
                player.GetComponent<PlayerController>().enabled = true;
                player.GetComponent<PlayerController>().isStopMoving = false;
            }    
        }
    }
}
