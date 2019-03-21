using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleremover : MonoBehaviour
{
    AudioSource audiosource;
    public float time;
    // Start is called before the first frame update
    void Start(){
    //audiosource = GetComponent<AudioSource>;

    
        Destroy(gameObject, time);
    }

   
}
