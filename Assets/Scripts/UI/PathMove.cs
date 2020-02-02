using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMove : MonoBehaviour
{
    public Transform endPoint = null;
    public float velocity = 30f;
    public float waitTime = 3f;

    private Vector3 path = Vector3.zero;
    private Vector3 moveSpeed;
    private float timeNeed, timePassed;
    // Start is called before the first frame update
    void Start()
    {
        if (endPoint != null)
        {
            path = endPoint.position - transform.position;
            moveSpeed = path.normalized * velocity;
            timeNeed = path.magnitude / velocity;
        }
    }

    private bool reachEnd = false;
    private float distAccepted = 0.05f;
    // Update is called once per frame
    void Update()
    {
        if (timePassed > waitTime && !reachEnd)
        {
            if (Vector3.Distance(transform.position, endPoint.position) <= distAccepted || timePassed >= timeNeed + waitTime)
            {
                reachEnd = true;
                transform.position = endPoint.position;
            }
            if (!reachEnd)
            {
                transform.position += moveSpeed * Time.deltaTime;
            }
        }
        timePassed += Time.deltaTime;

    }
}
