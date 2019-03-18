using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour

{
    // Start is called before the first frame update
    GameObject player;
    float curHealth;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        curHealth = player.GetComponent<PlayerHealth>().GetHealthPercent();
        this.GetComponent<Image>().fillAmount = curHealth;
    }
}