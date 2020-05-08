using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnNumber : MonoBehaviour
{
    public GameObject number;
    public List<string> numberSuite;
    float t;
    public bool spawnEnable;
    public Transform center;
    public bool inverse;
    public Animator[] animHole;
    public GameObject[] birds;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnDelay());
    }

    public void EnableAnimator()
    {
        Debug.Log("Animation");
        if(animHole.Length > 0)
        {
            foreach (var item in animHole)
            {
                item.enabled = true;
            }
        }
    }

    public void Update()
    {
        if(spawnEnable)
            t += Time.deltaTime / 3f;
    }

    IEnumerator SpawnDelay()
    {
        t = 0;
        Spawn();
        yield return new WaitForSeconds(3);
        if(numberSuite.Count > 0)
        {
            StartCoroutine(SpawnDelay());
        }
        else
        {
            Invoke("EnableAnimator", 15);
            foreach (var item in birds)
            {
                Destroy(item);
            }
        }
    }

    public void Spawn()
    {
        GameObject up = Instantiate(number);
        up.transform.parent = transform;
        up.transform.localScale = new Vector3(.1f, .1f, .1f);
        up.GetComponent<Archimed>().angleStart = 120;
        up.GetComponent<Archimed>().center = center;
        up.GetComponent<Archimed>().inverse = inverse;
        int random = Random.Range(0, numberSuite.Count);
        up.GetComponentInChildren<TextMesh>().text = numberSuite[random];
        numberSuite.RemoveAt(random);

        GameObject down = Instantiate(number);
        down.transform.parent = transform;
        down.transform.localScale = new Vector3(.1f, .1f, .1f);
        down.GetComponent<Archimed>().angleStart = 300;
        down.GetComponent<Archimed>().center = center;
        down.GetComponent<Archimed>().inverse = inverse;
        int random2 = Random.Range(0, numberSuite.Count);
        down.GetComponentInChildren<TextMesh>().text = numberSuite[random2];
        numberSuite.RemoveAt(random2);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
}
