using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFree : MonoBehaviour
{
    public float mouseSensi = 5;
    public string nomTarget;
    public GameObject[] birds;
    public GameObject destroyEgg;
    bool touch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == nomTarget)
                {
                    touch = true;
                }
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            touch = false;
        }

        if(touch)
        {
            float vertical = Input.GetAxis("Mouse Y");
            float horizontal = Input.GetAxis("Mouse X");
            transform.Translate(horizontal * mouseSensi * Time.deltaTime, 0, vertical * mouseSensi * Time.deltaTime);
        }

        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -.35f, 0.35f), 0, Mathf.Clamp(transform.localPosition.z, -0.43f, 0.43f));

        foreach(Transform tr in transform)
        {
            if (!tr.gameObject.activeInHierarchy)   
                return;
        }
        foreach (var item in birds)
        {
            item.SetActive(true);
        }
        Destroy(gameObject);
        Destroy(destroyEgg);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Side_1")
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.name == "Side_3")
        {
            transform.GetChild(2).gameObject.SetActive(true);
            Destroy(other.gameObject);
        }
    }

    public void Test()
    {
        birds[2].SetActive(true);
    }
}
