using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseSpiral : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public Transform center;

    // Time to move from sunrise to sunset position, in seconds.
    public float journeyTime = 1.0f;

    // The time at which the animation started.
    private float startTime;

    void Start()
    {
        // Note the time at the start of the animation.
        startTime = Time.time;
    }

    void Update()
    {
        // Interpolate over the arc relative to center
        Vector3 riseRelCenter = start.position - center.position;
        Vector3 setRelCenter = end.position - center.position;

        // The fraction of the animation that has happened so far is
        // equal to the elapsed time divided by the desired time for
        // the total journey.
        float fracComplete = (Time.time - startTime) / journeyTime;

        transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
        transform.position += center.position;
    }
}
