using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public float fullHealth;
    float currentHealth;
    public bool enemyDied = false;

    public Canvas enemyCanvas;
    public Slider enemyHealthSlider;

    private EnemyMove enemyController;

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = fullHealth;
        enemyHealthSlider.minValue = 0;
        enemyHealthSlider.maxValue = fullHealth;
        enemyHealthSlider.value = currentHealth;

        enemyController = GetComponent<EnemyMove>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void AddDamage(float damage)
    {
        currentHealth -= damage;
        enemyHealthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            enemyDied = true;
            enemyCanvas.enabled = false;
            MakeDied();
        }
    }

    public void MakeDied()
    {
        enemyController.Death();
        Destroy(gameObject, 3f);
    }
}
