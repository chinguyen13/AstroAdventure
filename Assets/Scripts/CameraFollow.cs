using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    public Transform player;

    [SerializeField]
    public Vector3 offset;

    [SerializeField]
    [Range(1,10)]
    public float smoothFactor;

    [SerializeField]
    public float leftLimit;
    [SerializeField]
    public float rightLimit;
    [SerializeField]
    public float topLimit;
    [SerializeField]
    public float bottomLimit;


    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 playerPosition = player.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, playerPosition, smoothFactor* Time.deltaTime);
        transform.position = smoothPosition;

        transform.position = new Vector3
            (
                Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
                Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
                transform.position.z
            );

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));

        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));

        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(leftLimit, bottomLimit));

        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit));
    }


}
