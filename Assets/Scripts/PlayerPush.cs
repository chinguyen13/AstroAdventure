using UnityEngine;

public class PlayerPush : MonoBehaviour
{
    public float distance = 1f;
    public LayerMask rockMask;

    public GameObject rock;

    public bool isTemple;
    private AudioScript audioScript;
    private bool isPlay;
    private bool isRock;
    private void Start()
    {
        audioScript = FindObjectOfType<AudioScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x,distance, rockMask);

        if (hit.collider != null && hit.collider.gameObject.tag == "Pushable" && Input.GetKey(KeyCode.E) && !Input.GetKey(KeyCode.Space) && gameObject.GetComponent<PlayerController>().isGrounded)
        {
            isRock = true;
            rock = hit.collider.gameObject;
            rock.GetComponent<FixedJoint2D>().enabled = true;
            rock.GetComponent<rockpull>().beingPushed = true;
            rock.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                if(!isPlay)
                {
                    audioScript.SFXs[7].Play();
                    isPlay = true;
                }

            }else
            {
                audioScript.SFXs[7].Stop();
                audioScript.SFXs[1].Stop();
                audioScript.SFXs[2].Stop();
                isPlay = false;
            }


        }
        else if (Input.GetKeyUp(KeyCode.E) || Input.GetKey(KeyCode.Space) || !gameObject.GetComponent<PlayerController>().isGrounded)
        {
            if(isPlay)
            {
                audioScript.SFXs[7].Stop();
                isPlay = false;
            }
            rock.GetComponent<FixedJoint2D>().enabled = false;
            rock.GetComponent<rockpull>().beingPushed = false;
        }else if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && isRock)
        {
            audioScript.SFXs[7].Stop();
            audioScript.SFXs[1].Stop();
            audioScript.SFXs[2].Stop();
            isPlay = false;
        }
 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }
}
