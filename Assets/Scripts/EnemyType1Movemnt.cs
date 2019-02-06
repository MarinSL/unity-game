using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType1Movemnt : MonoBehaviour {

    float amplitude = 2;
    float index = 0;
    float pi = Mathf.PI;
    float speed = 0.1f;
    float x, y;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        index++;
        x = amplitude * Mathf.Sin(index *0.1f * pi/20);
        y -= speed;
        amplitude = Random.Range(1, 5);
        transform.position = new Vector3(x, y, 0);
    }
}
