using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piller : MonoBehaviour
{
    public bool isBlock;
    public Vector3 pillerPos;
    private void Update()
    {
        if(isBlock)
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(transform.localPosition.x, -12, transform.localPosition.z), 2 * Time.deltaTime);
        else
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(transform.localPosition.x, -18, transform.localPosition.z), 2 * Time.deltaTime);
    }
}
