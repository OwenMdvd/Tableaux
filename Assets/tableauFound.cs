using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class tableauFound : MonoBehaviour
{
    public bool found;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in GetComponentsInChildren<VisualEffect>())
        {
            item.enabled = found;
        }
        foreach (var item in GetComponentsInChildren<Renderer>())
        {
            item.enabled = found;
        }
    }

    public void Lost()
    {
        found = false;
    }
    public void Found()
    {
        found = true;
    }
}
