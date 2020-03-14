using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiral : MonoBehaviour
{
    public float freq=1;
    float unit;
    private void Update()
    {
        transform.position = new Vector3(unit * Mathf.Cos(Time.time * freq), transform.position.y, unit * Mathf.Sin(Time.time * freq));
        unit -= Time.deltaTime;
    }
}
