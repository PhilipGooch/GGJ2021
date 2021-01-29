using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatMovement : MonoBehaviour
{
    public NavMeshAgent navAgent;
    public GameObject box;
    // Start is called before the first frame update
    void Start()
    {
        //navAgent.SetDestination(box.position);
        //navAgent.SetDestination(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        
        navAgent.SetDestination(Vector3.zero);
        if ((navAgent.destination - gameObject.transform.position).magnitude < 5) { 
            int asdf = 0;
        }
    }
}
