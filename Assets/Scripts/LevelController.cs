using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    float levelDuration = 0;
    [SerializeField]
    float timeLeft;
    float startTime;
    int lvl = 0;

    [SerializeField]
    bool changingLevel = false;


    [SerializeField]
    float changeDuration;

    GameObject[] backgrounds;
    SpriteRenderer[] spriteRenderers;

    //Fires on new level. Uses i.e. in LevelColorChanger
    public static event Action<int> LevelChanged;

    [SerializeField]
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
                timeLeft = Time.time - startTime;

                if (timeLeft >= levelDuration)
                {
                    lvl++;
                    lvlInProgress = false;
                    if (LevelChanged != null)
                        LevelChanged(lvl);


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