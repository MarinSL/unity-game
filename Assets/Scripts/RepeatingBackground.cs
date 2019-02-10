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
        if(transform.position.y > backgroundLength/2)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector2 backgroundOffset = new Vector2(0,- backgroundLength * 2f);
        transform.position = (Vector2)transform.position + backgroundOffset;
        transform.position =transform.position + new Vector3(0,0,2);
    }

}
