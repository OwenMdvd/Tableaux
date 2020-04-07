using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsGo : MonoBehaviour
{
    public Vector3 endPos;
    float t;
    Vector3 startPos;
    public bool end;
    public Transform center;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(center);
        t += Time.deltaTime / 5f;
        if (t > 1)
        {
            end = true;
            return;
        }

        transform.localPosition = Vector3.Lerp(startPos, endPos, t);
    }
}
