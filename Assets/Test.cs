using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Vector2[] pos;
    public float[] scaling;
    public float angle = 90;
    public GameObject carre;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < pos.Length; i++)
        {
            GameObject go = Instantiate(carre);
            go.transform.position = new Vector3(pos[i].x, 5, pos[i].y);
            go.transform.localScale = new Vector3(scaling[i], .1f, scaling[i]);
            go.transform.eulerAngles = new Vector3(0, angle, 0);
            angle = go.transform.eulerAngles.y;
            angle -= 90;
        }
    }
}
