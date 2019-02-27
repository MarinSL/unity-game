using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    float startTime;
    float levelDuration;
    int lvl = 1;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time-startTime>=levelDuration)
        {
            lvl++;
           // GetComponent<enemySpawner>().setEnemy();
            startTime = Time.time;
        }
    }
}
