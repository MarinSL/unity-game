using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int health;
    public int damage1;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enter");
        if(collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("EnemyBullet"))
        {
            health -= damage1;
            if (health <= 0) SceneManager.LoadScene(2);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
