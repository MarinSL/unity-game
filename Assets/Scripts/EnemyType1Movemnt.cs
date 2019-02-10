using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType1Movemnt : MonoBehaviour {
    public float amplitudeMin = 1;
    public float amplitudeMax = 5;
    public float frequencyMin = 1;
    public float frequencyMax = 5;
    public float speed = 150;

    float frequency;
    float amplitude;

    Vector3 initPos;
    
    void Start()
    {
        if (speed > 300) speed = 300;
        if (amplitude > 30) amplitude = 30;
        amplitude = Random.Range(amplitudeMin, amplitudeMax);
        frequency = Random.Range(frequencyMin, frequencyMax);
        initPos = transform.position;
      //  Debug.Log(initPos.x+", " + initPos.y);
    }

    void FixedUpdate()       
    {
        /*Random.seed = System.DateTime.Now.Millisecond;
        amplitude = Random.Range(1, 10);
        frequency = Random.Range(1, 2);
        transform.position += Mathf.Abs(Mathf.Sin(Mathf.PI / (300-speed))) * (amplitude * (Mathf.Sin(2 * Mathf.PI * frequency * (Time.time - Time.deltaTime)) - Mathf.Sin(2 * Mathf.PI * frequency * Time.time))) * transform.right;
        transform.position -= transform.up * Mathf.Abs(Mathf.Sin(Mathf.PI/(300-speed)));*/

        transform.position =  new Vector3(initPos.x + amplitude * Mathf.Sin(2 * Mathf.PI * frequency * Time.time) /*Mathf.PingPong(Time.time, amplitude)*/, transform.position.y- Mathf.Abs(Mathf.Sin(Mathf.PI / (300 - speed))), transform.position.z);
        //initPos = new Vector3(0, 0, 0);
    }
}
