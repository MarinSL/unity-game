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
        if (speed > 150) speed = 150;
        if (amplitude > 30) amplitude = 30;
        amplitude = Random.Range(amplitudeMin, amplitudeMax);
        frequency = Random.Range(frequencyMin, frequencyMax);
        initPos = transform.position;
    }

    void FixedUpdate()       
    {
        transform.position =  new Vector3(initPos.x + amplitude * Mathf.Sin(2 * Mathf.PI * frequency * Time.time), transform.position.y- Mathf.Abs(Mathf.Sin(Mathf.PI/2)), transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "BorderLeft")
        {
            transform.position = new Vector3(collision.gameObject.transform.position.x + 10, transform.position.y, transform.position.z);
        }
        if (collision.gameObject.name == "BorderRight")
        {
            transform.position = new Vector3(collision.gameObject.transform.position.x - 10, transform.position.y, transform.position.z);
        }

    }
}
