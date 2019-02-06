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
        // lastPosition = transform.position;
        amplitude = Random.Range(1, 5);
        frequency = Random.Range(1, 2);
        transform.position += amplitude * (Mathf.Sin(2 * Mathf.PI * frequency * (Time.time - Time.deltaTime)) - Mathf.Sin(2 * Mathf.PI * frequency * Time.time)) * transform.right;
        transform.position -= transform.up * Mathf.Sin(Mathf.PI/80);
    }
}
