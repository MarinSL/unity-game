using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D backCollider;
    private float backgroundLength;
    // Start is called before the first frame update
    void Start()
    {
        backCollider = GetComponent<BoxCollider2D>();
        backgroundLength = backCollider.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > backgroundLength*4)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector3 backgroundOffset = new Vector3(0,- backgroundLength * 8f, transform.position.z);
        transform.position = (Vector3)transform.position + backgroundOffset;
    }

}
