using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    public bool mustPatrol;

    public float walkSpeed;

    public float leftPos;
    public float rightPos;
    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if(this.transform.position.x <= leftPos || this.transform.position.x >= rightPos)
        {
            Flip();
        }
        transform.position += new Vector3(walkSpeed * Time.deltaTime, 0, 0);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        transform.position += new Vector3(walkSpeed*0.33333f, 0, 0);
        mustPatrol = true;
    }
}
