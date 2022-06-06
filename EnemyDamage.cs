using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyDamage : MonoBehaviour
{

    public float enemyDamageAmount;
    public DateTime nextDamage;
    public float damageAfterTime;
    public bool enemyInFightRange = false;

    public GameObject enemyObject;

    // Start is called before the first frame update
    void Awake()
    {
        nextDamage = DateTime.Now;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enemyInFightRange == true)
        {
            DamageEnemy();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyObject = other.gameObject;
            enemyInFightRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Enemy")
        {
            enemyInFightRange = false;
        }
    }

    public void DamageEnemy()
    {
        if (nextDamage <= DateTime.Now)
        {
            if(enemyObject.GetComponent<EnemyHealth>().enemyDied == false)
            {
                enemyObject.GetComponent<EnemyHealth>().AddDamage(enemyDamageAmount);
            }

            nextDamage = DateTime.Now.AddSeconds(System.Convert.ToDouble(damageAfterTime));
        }
    }
}
