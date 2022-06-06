using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour
{
    //GLOBAL
    public NavMeshAgent agent;
    public Animator anim;
    public float attackRange = 5f;
    public PlayerHealth pHealth;
    public GameObject detectionFight;


   
    //public int health = 100;


    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var player = FindObjectOfType<PlayerMove>();

        if (pHealth.playerDied == true)
        {
            agent.transform.LookAt(player.transform);
            Idle();
            detectionFight.SetActive(false);
        }                                                                                        //NAVMESH
        {
            if (agent.enabled)
                agent.SetDestination(player.transform.position);

            if (Vector3.Distance(transform.position, player.transform.position) < attackRange)     
                anim.SetTrigger("attackplayer");
        }
    }

  
    //ANIMATIONS
    void Attack()
    {
        anim.SetTrigger("attackplayer");
        agent.enabled = false;
    }

    void AttackCompleted()
    {
        agent.enabled = true;
    }

    void AttackHit()
    {
        Debug.Log("Player hit");
    }

    public void Idle()
    {
        agent.speed = 0f;
        anim.SetTrigger("Idle");
    }

    public void Death()
    {
        
        agent.speed = 0f;
        anim.SetTrigger("Death");

        
        SceneManager.LoadScene(1);
        

        //SceneManager.LoadScene(2);

        
    }
}
