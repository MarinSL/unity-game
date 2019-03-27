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
    public AudioSource impactsound;
    public Slider healthBarSlider;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("EnemyBullet")))
        {
            health -= damage1;
            impactsound.Play(1);
        }
    }

    private void Update()
    {
        if (health < 0) health = 0;
        if (health <= 0) SceneManager.LoadScene(2);
    }
    void Start()
    {
        InitialHealth = health;
    }

    public void RestoreHealth(float restoreValue)
    {
        if (health + InitialHealth * restoreValue <= InitialHealth)
        {
            health += InitialHealth * restoreValue;

        }
        else { health = InitialHealth; }
        healthBarSlider.value = health;
    }

    public void DecreaseHealth(float decreaseValue)
    {
        if (health - InitialHealth * decreaseValue >= 0)
        {
            health -= InitialHealth * decreaseValue;

        }
        else { health = 0; }
        healthBarSlider.value = health;
    }

    public float GetHealthPercent()
    {
        return health / InitialHealth;
    }

}