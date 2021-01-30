using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatMovement : MonoBehaviour
{
    public NavMeshAgent navAgent;
    private List<Vector3> holePositions;
    private Vector3 boxPosition;
    public int start;
    public int end;
    Vector3 velocity;

    void Start()
    {
        boxPosition = Vector3.zero;

        holePositions = new List<Vector3>();
        holePositions.Add(new Vector3(-200, 0, -250));
        holePositions.Add(new Vector3(-100, 0, -250));
        holePositions.Add(new Vector3(-0, 0, -250));
        holePositions.Add(new Vector3(100, 0, -250));
        holePositions.Add(new Vector3(200, 0, -250));
        holePositions.Add(new Vector3(250, 0, -200));
        holePositions.Add(new Vector3(250, 0, -100));
        holePositions.Add(new Vector3(250, 0, 0));
        holePositions.Add(new Vector3(250, 0, 100));
        holePositions.Add(new Vector3(250, 0, 200));
        holePositions.Add(new Vector3(200, 0, 250));
        holePositions.Add(new Vector3(100, 0, 250));
        holePositions.Add(new Vector3(0, 0, 250));
        holePositions.Add(new Vector3(-100, 0, 250));
        holePositions.Add(new Vector3(-200, 0, 250));
        holePositions.Add(new Vector3(-250, 0, 200));
        holePositions.Add(new Vector3(-250, 0, 100));
        holePositions.Add(new Vector3(-250, 0, 0));
        holePositions.Add(new Vector3(-250, 0, -100));
        holePositions.Add(new Vector3(-250, 0, -200));

        navAgent.SetDestination(Vector3.zero);

        //velocity = boxPosition - gameObject.trans
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Box")
        {


            navAgent.SetDestination(holePositions[end]);
        }
    }
}
