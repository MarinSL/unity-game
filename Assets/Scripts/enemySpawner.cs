using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;
    public float spawnRate;
    public float spawnRangeMin = -2.5f;
    public float spawnRangeMax =2.5f;
    float timeStart;
    float timeDif;
	// Use this for initialization
	void Start () {
        timeStart = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        timeDif = Time.time - timeStart;
        if (timeDif > spawnRate)
        {
            GameObject enemy;
            enemy = Instantiate(enemyPrefab);
            Vector3 newPos = new Vector3(transform.position.x + Random.Range(spawnRangeMin, spawnRangeMax), 0, 0);
            enemy.transform.position = transform.position + newPos;
            timeStart = Time.time;
        }
	}
}
