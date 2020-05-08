using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovScaler : MonoBehaviour
{
    public Camera cam;
    // Update is called once per frame
    void Update()
    {
        Debug.Log(cam.fieldOfView);
        GetComponent<Camera>().fieldOfView = cam.fieldOfView;
    }
}
