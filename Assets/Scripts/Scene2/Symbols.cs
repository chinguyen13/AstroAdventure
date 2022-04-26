using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Symbols : MonoBehaviour
{
    private GameObject player;
    public GameObject holywood;
    private bool isStop;
    private bool isBright;
    public Light2D _light;
    public GameObject symbol;
    public float timeLeft = 2;
    private bool isTriggered;
    public GameObject torch;
    public Camera cam2;
    private Camera cam1;
    private OpenGate openGate;
    public Transform gateDoor;
    private bool doorOpened;
    public GameObject goDoor;
    private AudioScript audioScript;
    // Start is called before the first frame update
    void Start()
    {
        audioScript = FindObjectOfType<AudioScript>();
        player = FindObjectOfType<PlayerController>().gameObject;
        cam1 = Camera.main;
        openGate = FindObjectOfType<OpenGate>();
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
        if (player.GetComponent<PlayerController>().isStopMoving && !isStop && player.GetComponent<PlayerController>().isGrounded && isTriggered)
        {
            player.GetComponent<PlayerController>().enabled = false;
            holywood.SetActive(true);
            isStop = true;
            StartCoroutine(SymbolsBright());

        }
        if (isBright)
        {
            symbol.GetComponent<SpriteRenderer>().color = Color.Lerp(symbol.GetComponent<SpriteRenderer>().color, new Color(1, 1, 1, 1), Time.deltaTime / (timeLeft/5));
            _light.color = Color.Lerp(_light.color, new Color(1,1,1,1), Time.deltaTime / timeLeft);
            if (symbol.GetComponent<SpriteRenderer>().color == new Color(1,1,1,1))
            {
                isBright = false;
            }
           
        }
        if(doorOpened)
        {
            gateDoor.position = Vector3.Lerp(gateDoor.position, new Vector3(gateDoor.position.x, 3.5f, gateDoor.position.z), Time.deltaTime * 0.5f);
            if(gateDoor.position.y == 3.5f)
            {
                doorOpened = false;
            }
        }

    }

    IEnumerator SymbolsBright()
    {
        yield return new WaitForSeconds(1f);
        audioScript.SFXs[14].Play();
        isBright = true;
        yield return new WaitForSeconds(timeLeft+1.5f);
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        for(int i = 1; i < torch.transform.childCount;i++)
        {
            torch.transform.GetChild(i).gameObject.SetActive(true);
        }
        openGate.torchCount++;
        if(openGate.torchCount == 2)
        {
            yield return new WaitForSeconds(2f);
            doorOpened = true;
            cam2.GetComponent<CamShake>().Shake(4f, 0.05f);
            yield return new WaitForSeconds(2f);
            goDoor.SetActive(true);
        }
        yield return new WaitForSeconds(3f);
        cam1.gameObject.SetActive(true);
        cam2.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        holywood.GetComponent<Animator>().SetBool("isHolywoodEnd", true);
        yield return new WaitForSeconds(1f);
        holywood.SetActive(false);
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<PlayerController>().isStopMoving = false;
        Destroy(this.gameObject, 1f);
    }
}
