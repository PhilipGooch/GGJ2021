using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatMovement : MonoBehaviour
{
    public NavMeshAgent navAgent;
    public GameObject box;

    void Start()
    {
        int f = 0;
        navAgent.SetDestination(Vector3.zero);
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        //if(other.gameobject.tag == "Box")
        //{
        //    navAgent.SetDestination(Vector3(250, 0, 0));
        //}
    }
}
