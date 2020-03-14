using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSpiral : MonoBehaviour
{
    public Vector3 start;
    public Transform[] end;
    public Transform[] center;
    int index = 0;

    // Time to move from sunrise to sunset position, in seconds.
    public float journeyTime = 1.0f;

    // The time at which the animation started.
    private float startTime;

    void Start()
    {
        // Note the time at the start of the animation.
        startTime = Time.time;
        start = transform.localPosition;
    }

    void Update()
    {
        // Interpolate over the arc relative to center
        Vector3 riseRelCenter = start - center[index].localPosition;
        Vector3 setRelCenter = end[index].localPosition - center[index].localPosition;

        float fracComplete = (Time.time - startTime) / journeyTime;

        transform.localPosition = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
        transform.localPosition += center[index].localPosition;
        //transform.localPosition = Vector3.Lerp(start, new Vector3(.3f,.1f,0), fracComplete);

        if (fracComplete >= 1)
        {
            start = transform.localPosition;
            fracComplete = 0;
            startTime = Time.time;
            index++;
            journeyTime -= .75f;
            if (index >= end.Length)
            {
                //Destroy(gameObject);
            }
        }
    }
}
