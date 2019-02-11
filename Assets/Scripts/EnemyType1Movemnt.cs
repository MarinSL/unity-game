using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType1Movemnt : MonoBehaviour {
    public float amplitudeMin = 1;
    public float amplitudeMax = 5;
    public float frequencyMin = 1;
    public float frequencyMax = 5;
    public float speed = 1;

    float frequency;
    float amplitude;

    Vector3 initPos;
    
    void Start()
    {
        if (speed > 150) speed = 150;
        if (amplitude > 30) amplitude = 30;
        amplitude = Random.Range(amplitudeMin, amplitudeMax);
        frequency = Random.Range(frequencyMin, frequencyMax);
        initPos = transform.position;
    }

    void FixedUpdate()       
    {
        transform.position =  new Vector3(initPos.x + amplitude * Mathf.Sin(2 * Mathf.PI * frequency * Time.time), transform.position.y-speed*Mathf.Abs(Mathf.Sin(Mathf.PI/200)), transform.position.z);
    }
}
