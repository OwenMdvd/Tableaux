using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class moveNumber : MonoBehaviour
{
    public float mouseSensi = 5;
    public float lastPos;
    public string nomTarget;
    public GameObject[] next;
    public GameObject destroyGo;

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

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == nomTarget)
                {
                    Debug.Log("Touche");
                    float vertical = Input.GetAxis("Mouse Y");
                    transform.Translate(0, 0, vertical * mouseSensi * Time.deltaTime);
                }
            }
        }
        transform.localPosition = new Vector3(0, 0, Mathf.Clamp(transform.localPosition.z, -0.242f, lastPos));

        if(transform.localPosition.z <= -0.242f)
        {
            foreach (var item in next)
            {
                item.SetActive(true);
            }
            GetComponent<MoveFree>().enabled = true;
            Destroy(this);
            Destroy(destroyGo);
            //destroyGo.GetComponent<VisualEffect>().Stop();
            //destroyGo.GetComponent<VisualEffect>().SendEvent("Broken");
        }
    }
}
