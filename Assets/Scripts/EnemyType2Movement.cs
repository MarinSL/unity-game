using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType2Movement : MonoBehaviour
{
    public float amplitudeMin = 1;
    public float amplitudeMax = 5;
    public float frequencyMin = 1;
    public float frequencyMax = 5;
    public float speed = 1;
    public float speedMultipl = 10;
    public float firstPhaseLength = 4;

    float frequency;
    float amplitude;
    float startingTime;
    float curTime;

    bool AttackStarted = false;

    Vector3 initPos;
    Vector3 playerPos;
    Vector3 curPos;
    Vector3 delta;
    GameObject player;

    void Start()
    {
        if (speed > 150) speed = 150;
        if (amplitude > 30) amplitude = 30;
        amplitude = Random.Range(amplitudeMin, amplitudeMax);
        frequency = Random.Range(frequencyMin, frequencyMax);
        initPos = transform.position;

        player = GameObject.Find("Player");

        startingTime = Time.time;
    }

    void Wave()
    {
        transform.position = new Vector3(initPos.x + amplitude * Mathf.Sin(2 * Mathf.PI * frequency * Time.time), transform.position.y - speed * Mathf.Abs(Mathf.Sin(Mathf.PI / 200)), transform.position.z);
    }

    void Attack()
    {
        float moveSpeed = speed * Time.deltaTime;
        transform.position = transform.position - (delta * moveSpeed);
    }
    // Update is called once per frame
    void Update()
    {
        curTime = Time.time;
        if(curTime-startingTime < firstPhaseLength)
        {
            Wave();
        } else
        {  
            if (!AttackStarted) {
                speed *= speedMultipl;
                playerPos = player.transform.position;
                curPos = transform.position;
                delta = curPos - playerPos;
                delta.Normalize();
            }
            AttackStarted = true;
            Attack();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
