using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    float levelDuration = 10;
    [SerializeField]
    float timePassed;
    [SerializeField]
    int lvlWithoutWeapon;
    float startTime;
    int lvl = 0;

    bool changingLevel = false;

    GameObject[] backgrounds;
    SpriteRenderer[] spriteRenderers;
    PlayerShoot ps;
    GameObject player;
    //Fires on new level. Uses i.e. in LevelColorChanger
    public static event Action<int> LevelChanged;

    private bool lvlInProgress = true;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        EnemySpawner.SpawnFinished += OnEnemySpawnFinished;
        player = GameObject.FindWithTag("Player");
        ps = player.GetComponent<PlayerShoot>();
        lvlWithoutWeapon--;
    }

    // Update is called once per frame
    void Update()
    {
        if (lvlInProgress)
        {
            if (lvl < 6)
            {
                timePassed = Time.time - startTime;
                if (timePassed >= levelDuration || lvl == 0)
                {
                    lvlInProgress = false;

                    if (lvl == lvlWithoutWeapon && ps != null)
                    {
                        ps.setWeaponAvailible(false);
                        player.GetComponent<Movement>().ChangeSprite(false);
                    }

                    else if (lvl == lvlWithoutWeapon + 1 && ps != null)
                    {
                        ps.setWeaponAvailible(true);
                        player.GetComponent<Movement>().ChangeSprite(true);
                    }

                    if (LevelChanged != null)
                        LevelChanged(lvl);

                    lvl++;
                    startTime = Time.time;
                }
            }
            else
            {
                //win scene
                SceneManager.LoadScene(2);

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