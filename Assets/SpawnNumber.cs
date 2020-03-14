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
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnDelay());
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
    }

    public void Spawn()
    {
        GameObject up = Instantiate(number);
        up.transform.parent = transform;
        up.GetComponent<Archimed>().posStart = -.15f;
        up.GetComponent<Archimed>().angleStart = 120;
        int random = Random.Range(0, numberSuite.Count);
        up.GetComponentInChildren<TextMesh>().text = numberSuite[random];
        numberSuite.RemoveAt(random);


        GameObject down = Instantiate(number);
        down.transform.parent = transform;
        down.GetComponent<Archimed>().posStart = .15f;
        down.GetComponent<Archimed>().angleStart = 300;
        int random2 = Random.Range(0, numberSuite.Count);
        down.GetComponentInChildren<TextMesh>().text = numberSuite[random2];
        numberSuite.RemoveAt(random2);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
}
