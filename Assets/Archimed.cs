using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archimed : MonoBehaviour
{
    public float divide;
    public float angleStart;
    public bool active = true;
    public bool inverse;

    public Transform center;
    float r;
    float a;
    float t;
    Vector3 start;
    bool doOnce;

    // Start is called before the first frame update
    void Start()
    {
        r = 100;
        if (inverse)
        {
            a = (angleStart - 60) * Mathf.Deg2Rad;
        }
        else
        {
            a = angleStart * Mathf.Deg2Rad;
        }
        start = new Vector3((r * Mathf.Cos(a) / divide), 0, (r * Mathf.Sin(a) / divide));
        transform.localPosition = start;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            float x = r * Mathf.Cos(a);
            float y = r * Mathf.Sin(a);
            if (inverse)
            {
                a += 0.01f;
                r -= 0.05f;
            }
            else
            {
                a -= 0.01f;
                r -= 0.05f;
            }
            r = Mathf.Clamp(r, 0, 100);
            transform.localPosition = new Vector3(x / divide, 0, y / divide);
            if(!doOnce)
            {
                doOnce = true;
                Debug.Log(transform.localPosition);
            }
        }
        if(r <= 0)
        {
            Destroy(gameObject);
        }
        transform.LookAt(center);
    }
}
