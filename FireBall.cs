using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject ball;
    public Transform fireBall;
    public float shootForce;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            GameObject ballInstantiate  = (GameObject)Instantiate(ball,fireBall.position,fireBall.rotation);

            ballInstantiate.GetComponent<Rigidbody>().AddForce(fireBall.up * shootForce);

        }
    }
}
