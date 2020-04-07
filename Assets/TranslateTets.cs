using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateTets : MonoBehaviour
{
    public float mouseSensi = 5;
    public float lastPos;
    public GameObject next;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastPos > transform.localPosition.z)
            lastPos = transform.localPosition.z;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Input.GetAxis("Fire1") > 0)
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Target")
                {
                    Debug.Log("Touche");
                    float vertical = Input.GetAxis("Mouse Y");
                    transform.Translate(0, 0, vertical * mouseSensi * Time.deltaTime);
                    transform.localPosition = new Vector3(0, .25f, Mathf.Clamp(transform.localPosition.z, 0, lastPos));
                }
            }
        }
        if(transform.localPosition.z == 0)
        {
            next.SetActive(true);
        }
    }
}
