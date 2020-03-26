using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerFirst : MonoBehaviour
{
    public List<GameObject> targets = new List<GameObject>();
    public GameObject[] nextEtape;

    // Update is called once per frame
    void Update()
    {
        if(targets.Count == 2)
        {
            foreach (var item in targets)
            {
                Destroy(item);
            }
            targets.Clear();
            foreach (var item in nextEtape)
            {
                item.SetActive(true);
            }
            Destroy(this);
        }
    }
}
