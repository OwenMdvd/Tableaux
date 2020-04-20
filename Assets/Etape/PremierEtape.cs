using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PremierEtape : MonoBehaviour
{
    public string nomTarget;
    public ManagerFirst manager;
    bool active;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !active)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == nomTarget)
                {
                    active = true;
                    manager.targets.Add(gameObject);
                }
            }
        }
    }
}
