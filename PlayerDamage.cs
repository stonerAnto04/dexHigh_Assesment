using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDamage : MonoBehaviour
{

    public float playerDamageAmount;
    public bool playerInRange = false;
    public DateTime nextDamage;
    public float damageAfterTime;

    public GameObject playerObject;

    // Start is called before the first frame update
    void Awake()
    {
        nextDamage = DateTime.Now;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerInRange == true)
        {
            DamagePlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.gameObject.GetComponent<PlayerHealth>().playerDied == false)
            {
                playerObject = other.gameObject;
                playerInRange = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerInRange = false;
        }
    }

    public void DamagePlayer()
    {
        if (nextDamage <= DateTime.Now)
        {
            if (playerObject.GetComponent<PlayerHealth>().playerDied == false)
            {
                playerObject.GetComponent<PlayerHealth>().AddDamage(playerDamageAmount);
                nextDamage = DateTime.Now.AddSeconds(System.Convert.ToDouble(damageAfterTime));
            }          
        }
    }
}
