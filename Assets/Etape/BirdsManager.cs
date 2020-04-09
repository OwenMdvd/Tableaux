using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsManager : MonoBehaviour
{
    public BirdsGo[] birds;
    public SpawnNumber[] spirals;
    public GameObject[] holes;
    // Update is called once per frame
    void Update()
    {
        foreach (var item in birds)
        {
            if (!item.end)
                return;
        }
        foreach (var item in spirals)
        {
            item.enabled = true;
        }
        foreach (var item in holes)
        {
            item.SetActive(true);
        }
    }
}
