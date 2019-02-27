using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int health;
    float DamageSliderValue;
    public int damage1;
    public Slider healthBarSlider;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if((collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("EnemyBullet")) && healthBarSlider.value > 0)

        {
            health -= damage1;
            healthBarSlider.value -= DamageSliderValue;
            if (health <= 0) SceneManager.LoadScene(2);
        }
    }
    void Start()
    {
        DamageSliderValue = healthBarSlider.value *  damage1 / health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
