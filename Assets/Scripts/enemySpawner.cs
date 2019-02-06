using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject enemy;
        enemy = Instantiate(enemyPrefab);
        Vector3 newPos = new Vector3(transform.position.x + Random.Range(-5, 5), transform.position.y, 0);
        enemy.transform.position = transform.position + newPos;
	}
}
