using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject prefabToSpawn;
    public float spawnInterval = 2.0f;

    private float spawnWait;


    private void Start()
    {
        spawnWait = spawnInterval;
    }

    // Update is called once per frame
    void Update () {
        spawnWait -= Time.deltaTime;

        if(spawnWait <= 0)
        {
            spawnWait = spawnInterval;

            if(prefabToSpawn)
            {
                GameObject spawn = Instantiate(prefabToSpawn);
                spawn.transform.position = transform.position;
                spawn.SetActive(true);
            }
        }
	}
}
