using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomStars : MonoBehaviour
{
    public GameObject star;
    public bool stopSpawning = false;
    public float spawnTimeMin;
    public float spawnTimeMax;
    public float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", Random.Range(spawnTimeMin,spawnTimeMax), spawnDelay);
    }

    public void SpawnObject()
    {
        //To wait, type this:
        Instantiate(star, new Vector3(Random.Range(-11f, 11f), 6, 0), Quaternion.identity);
        //Stuff before waiting
        if(stopSpawning){
            CancelInvoke("SpawnObject");
        }
        //Stuff after waiting.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
