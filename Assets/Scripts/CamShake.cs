using UnityEngine;

public class CamShake : MonoBehaviour
{
    [HideInInspector]
    public bool isShake;
    private float elapsed = 0f;
    private Vector3 originalPos;
    private float spread;
    private float duration;

    public void Shake(float _duration, float _spread)
    {
        originalPos = transform.localPosition;
        duration = _duration;
        spread = _spread;
        if(this.gameObject.name == "Main Camera")
            this.GetComponent<CameraFollow>().enabled = false;
        isShake = true;
    }

    private void Update()
    {
        if(isShake)
        {
            if(elapsed < duration)
            {
                float x = Random.Range(originalPos.x - spread, originalPos.x + spread);
                float y = Random.Range(originalPos.y - spread, originalPos.y + spread);
                transform.localPosition = new Vector3(x, y, originalPos.z);
                elapsed += Time.deltaTime;
            }else
            {
                transform.localPosition = originalPos;
                if (this.gameObject.name == "Main Camera")
                    this.GetComponent<CameraFollow>().enabled = true;
                isShake = false;
            }

            
        }    
    }
}
