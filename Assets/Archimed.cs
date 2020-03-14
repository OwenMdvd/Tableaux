using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archimed : MonoBehaviour
{
    public float posStart;
    public float divide;
    public float angleStart;
    public bool active = true;

    Transform center;
    bool first = true;
    float r;
    float a;
    float t;
    Vector3 start;

    // Start is called before the first frame update
    void Start()
    {
        center = GameObject.FindGameObjectWithTag("Center").transform;
        r = 100;
        a = angleStart * Mathf.Deg2Rad;
        start = new Vector3((r * Mathf.Cos(a) / divide) + posStart, 0.1f, (r * Mathf.Sin(a) / divide) + posStart);
        transform.localPosition = start;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (!first)
            {
                float x = r * Mathf.Cos(a);
                float y = r * Mathf.Sin(a);
                a -= 0.01f;
                r -= 0.05f;
                r = Mathf.Clamp(r, 0, 100);
                transform.localPosition = new Vector3(x / divide, .1f, y / divide);
            }
            else
            {
                t += Time.deltaTime / .2f;
                transform.localPosition = Vector3.Lerp(start, new Vector3(r * Mathf.Cos(a) / divide, 0.1f, r * Mathf.Sin(a) / divide), t);
                if (t >= 1)
                {
                    first = false;
                }
            }
        }
        if(r <= 0)
        {
            Destroy(gameObject);
        }
        transform.LookAt(center);
    }
}
