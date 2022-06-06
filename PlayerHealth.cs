using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    
    public float fullHealth;
    float currHealth;
    public bool playerDied = false;

    PlayerMove playerController;

    public Canvas playerCanvas;
    public Slider playerHealthSlider;
    // Start is called before the first frame update
    void Awake()
    {
        currHealth = fullHealth;
        playerHealthSlider.minValue = 10;
        playerHealthSlider.maxValue = fullHealth;
        playerHealthSlider.value = currHealth;

        playerController = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void AddDamage(float damage)
    {
        currHealth -= damage;
        playerHealthSlider.value = currHealth;

        if (currHealth <= 0)
        {
            playerDied = true;
            playerCanvas.enabled = false;
            playerController.Death();
            playerController.enabled = false;
            //Destroy(gameObject);

        }
    }
}
