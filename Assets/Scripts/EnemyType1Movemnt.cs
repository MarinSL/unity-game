using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType1Movemnt : MonoBehaviour {

    float amplitude = 2;
    float index = 0;
    float pi = Mathf.PI;
    float speed = 0.3f;
    float x, y;
    float frequency = 0.5f;
    void Start()
    {
      
    }

    void FixedUpdate()       
    {
        Random.seed = System.DateTime.Now.Millisecond;
        // lastPosition = transform.position;
        amplitude = Random.Range(1, 10);
        frequency = Random.Range(1, 2);
        transform.position += Mathf.Abs(Mathf.Sin(Mathf.PI / 50)) * (amplitude * (Mathf.Sin(2 * Mathf.PI * frequency * (Time.time - Time.deltaTime)) - Mathf.Sin(2 * Mathf.PI * frequency * Time.time))) * transform.right;
        transform.position -= transform.up * Mathf.Abs(Mathf.Sin(Mathf.PI/100));
    }
}
