using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingCamera : MonoBehaviour
{
    private bool shouldLerp = false;

    private float timeStartedLerping;
    public float lerpTime;

    public Vector3 endPosition;
    public Vector3 startPosition;

    public GameObject playerStart;
    private CameraFollow cam;
    public GameObject player;
    private Animator anim;

    private void startLerping()
    {
        timeStartedLerping = Time.time;
        shouldLerp = true;
    }

    
    private void Start()
    {
        cam = FindObjectOfType<CameraFollow>();
        anim = playerStart.GetComponent<Animator>();
        player.SetActive(false);
        cam.enabled = false;
        anim.enabled = true;
        startLerping();

    }


    private void Update()
    {
        if(shouldLerp)
        {
            transform.position = Lerp(startPosition, endPosition, timeStartedLerping, lerpTime);
        }
        if(transform.position == endPosition)
        {
            anim.SetBool("isStarted", true);
            StartCoroutine(waitForStart());
        }
    }

    IEnumerator waitForStart()
    {
        yield return new WaitForSeconds(2.51f);
        gameObject.GetComponent<StartingCamera>().enabled = false;
        cam.enabled = true;
        yield return new WaitForSeconds(0.05f);
        Destroy(playerStart);
        player.SetActive(true);
        


    }

    public Vector3 Lerp(Vector3 start, Vector3 end, float timeStartedLerping, float lerpTime = 1)
    {
        float timeSinceStarted = Time.time - timeStartedLerping;

        float percentageComplete = timeSinceStarted / lerpTime;

        var result = Vector3.Lerp(start, end, percentageComplete);

        return result;
    }
}
