using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    float levelDuration = 10;

    float timePassed;
    float startTime;
    int lvl = 0;
    
    bool changingLevel = true;


    [SerializeField]
    float changeDuration;

    GameObject[] backgrounds;
    SpriteRenderer[] spriteRenderers;

    //Fires on new level. Uses i.e. in LevelColorChanger
    public static event Action<int> LevelChanged;

    private bool lvlInProgress = true;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        EnemySpawner.SpawnFinished += OnEnemySpawnFinished;
    }

    // Update is called once per frame
    void Update()
    {
        if (lvlInProgress)
        {
            if (lvl < 5)
            {
                timePassed = Time.time - startTime;
                if (timePassed >= levelDuration || lvl == 0)
                {
                    lvlInProgress = false;
                    if (LevelChanged != null)
                        LevelChanged(lvl);
                    lvl++;
                    startTime = Time.time;
                }
            }
        }
    }

    public float getLevelDuration()
    {
        return levelDuration;
    }

    private void OnEnemySpawnFinished()
    {
        lvlInProgress = true;
        startTime = Time.time;
    }

}