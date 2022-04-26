using UnityEngine;

public class LeverAndGate : MonoBehaviour
{
    private bool isTriggered;
    public Transform gate;
    public Transform lever;
    private bool isGate;
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
        if(isTriggered)
        {
            if(Input.GetKeyDown(KeyCode.E) && !isGate)
            {
                isGate = true;
            }
        }
        if (isGate)
        {
            if (!isPlay)
            {
                audioScript.SFXs[13].Play();
                isPlay = true;
            }
            gate.transform.Translate(Vector3.down * 3f * Time.deltaTime, Space.Self);
            lever.localRotation = Quaternion.Slerp(lever.localRotation, Quaternion.Euler(Vector3.forward * 25f), 4f * Time.deltaTime);
            Destroy(this.gameObject, 2f);
        }
    }
}
