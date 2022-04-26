using System.Collections;
using UnityEngine;

public class SpiritMove : MonoBehaviour
{
    private GameObject player;
    public GameObject holywood;
    public GameObject spirit;
    public GameObject whiteScreen;
    private bool isStop;
    private Camera cam;
    public GameObject gate;
    private bool isGate;
    private bool isTriggered;
    private AudioScript audioScript;
    private bool isPlay;
    public AudioSource spiritAudio;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        cam = Camera.main;
        audioScript = FindObjectOfType<AudioScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player && !isTriggered)
        {
            player.GetComponent<PlayerController>().isStopMoving = true;
            player.GetComponent<PlayerController>().moveInput = 0;
            player.GetComponent<Animator>().SetBool("isRunning", false);
            isStop = false;
            isTriggered = true;
        }
    }
    private void Update()
    {
        if(player.GetComponent<PlayerController>().isStopMoving && !isStop && player.GetComponent<PlayerController>().isGrounded && isTriggered)
        {
            player.GetComponent<PlayerController>().enabled = false;
            holywood.SetActive(true);
            isStop = true;
            StartCoroutine(CamFollow());

        }
        if(isGate)
        {
            if(!isPlay)
            {
                audioScript.SFXs[10].Play();
                isPlay = true;
            }
            gate.transform.position = Vector3.Lerp(gate.transform.position, new Vector3(gate.transform.position.x, -7.5f, gate.transform.position.z), Time.deltaTime);
        }
           
    }

    IEnumerator CamFollow()
    {
        spiritAudio.Stop();
        spiritAudio.Play();
        yield return new WaitForSeconds(1f);
        cam.GetComponent<CameraFollow>().player = spirit.transform;
        cam.GetComponent<CameraFollow>().smoothFactor = 7f;
        spirit.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(3.3f);
        player.transform.localScale = new Vector3(1.2f, 1.2f, 1f);
        yield return new WaitForSeconds(6.2f);
        whiteScreen.SetActive(true);
        audioScript.SFXs[9].Play();
        yield return new WaitForSeconds(0.6f);
        player.transform.position = new Vector3(-145f, -3.5f, 0);
        cam.GetComponent<CameraFollow>().smoothFactor = 4f;
        Destroy(spirit);
        cam.GetComponent<CameraFollow>().player = gate.transform;
        gate.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0.990566f, 0.8790952f, 0.2476415f, 1);
        yield return new WaitForSeconds(2.4f);
        whiteScreen.SetActive(false);
        yield return new WaitForSeconds(0.6f);
        isGate = true;
        cam.GetComponent<CamShake>().Shake(2.9f, 0.05f);
        yield return new WaitForSeconds(4f);
        cam.GetComponent<CameraFollow>().player = player.transform;
        holywood.GetComponent<Animator>().SetBool("isHolywoodEnd",true);
        yield return new WaitForSeconds(1f);
        holywood.SetActive(false);
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<PlayerController>().isStopMoving = false;
        Destroy(this.gameObject, 2f);
    }
}
