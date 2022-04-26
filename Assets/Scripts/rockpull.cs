using UnityEngine;

public class rockpull : MonoBehaviour
{
    public bool beingPushed;
    public float xPos;
    // Start is called before the first frame update
    void Start()
    {
        xPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (!beingPushed)
        {
            transform.position = new Vector3(xPos, transform.position.y);
        }
        else
            xPos = transform.position.x;
    }
}
