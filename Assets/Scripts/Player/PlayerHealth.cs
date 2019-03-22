using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float health;
    float DamageSliderValue;
    float InitialHealth;
    public int damage1;
    public Slider healthBarSlider;
    public AudioSource impactsound;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("EnemyBullet")) && healthBarSlider.value > 0)
        {
            health -= damage1;
            if (health < 0) health = 0;
            //healthBarSlider.value -= DamageSliderValue;
            if (healthBarSlider.value < 0) healthBarSlider.value = 0;
            //Debug.Log(health/ InitialHealth);
            impactsound.Play(1);
            //healthBarSlider.image.fillAmount = health/InitialHealth;
            if (health <= 0) SceneManager.LoadScene(2);
        }
    }
    void Start()
    {
        InitialHealth = health;
        DamageSliderValue = healthBarSlider.value * damage1 / InitialHealth;
    }

    public void RestoreHealth(float restoreValue)
    {
        if (health + InitialHealth * restoreValue <= InitialHealth)
        {
            health += InitialHealth * restoreValue;
            healthBarSlider.value = health;
            
        }
    }

    public float GetHealthPercent()
    {
        return health / InitialHealth;
    }
    // Update is called once per frame
    void Update()
    {

    }
}