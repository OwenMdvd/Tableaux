using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsManager : MonoBehaviour
{
    public BirdsGo[] birds;
    public SpawnNumber[] spirals;
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
    }
}
