using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    // public GameObject enemyPrefab;
    public float spawnRate;
    public float spawnRangeMin = -2.5f;
    public float spawnRangeMax = 2.5f;
    float timeStart;
    float timeDif;

    [SerializeField]
    GameObject[] enemies = new GameObject[3];

    List<GameObject> enemyList = new List<GameObject>();
    public static event Action SpawnFinished;

    // Use this for initialization
    void Start()
    {
        timeStart = Time.time;
        ShowNarrative.NarrativeFinished += OnNarrativeFinished;
        ShowNarrative.NarrativeStarted += OnNarrativeStarted;
    }

    // Update is called once per frame
    void Update()
    {
        timeDif = Time.time - timeStart;
        if (timeDif > spawnRate)
        {
            foreach (GameObject enemyPrefab in enemyList)
            {
                GameObject enemy;
                enemy = Instantiate(enemyPrefab);
                Vector3 newPos = new Vector3(transform.position.x + UnityEngine.Random.Range(spawnRangeMin, spawnRangeMax), 0, 0);
                enemy.transform.position = transform.position + newPos;
            }
            timeStart = Time.time;
        }
    }

    public void addEnemy(GameObject enemy)
    {
        enemyList.Add(enemy);
    }

    public void clearEnemies()
    {
        enemyList.Clear();
    }

    public void Pause(float pauseLength)
    {

    }

    private void OnNarrativeFinished(int lvl)
    {
        ChangeEnemies(lvl);
        if (SpawnFinished != null)
            SpawnFinished();
        Debug.Log("not waiting");
    }

    private void OnNarrativeStarted(int lvl)
    {
        clearEnemies();
    }

    private void ChangeEnemies(int lvl)
    {
        switch (lvl)
        {
            case 0:
                addEnemy(enemies[0]);
                break;
            case 1:
                addEnemy(enemies[1]);
                break;
            case 2:
                addEnemy(enemies[2]);
                break;
            case 3:
                addEnemy(enemies[3]);
                break;
            case 4:
                addEnemy(enemies[4]);
                break;
        }
    }
}