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
    private BoxContainer box;
    private GameObject marble;

    InGameManager gameManager;
    bool reachedBox = false;

    void Start()
    {
        box = FindObjectOfType<BoxContainer>();

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


        gameManager = FindObjectOfType<InGameManager>();
        //navAgent.SetDestination(Vector3.zero);

        //velocity = boxPosition - gameObject.trans
    }

    void Update()
    {
        if (gameManager.gameStarted && !reachedBox)
        {
            navAgent.SetDestination(Vector3.zero);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Box")
        {
            TakeMarble();
            reachedBox = true;
            navAgent.SetDestination(holePositions[end]);
        }
    }
    void TakeMarble()
    {
        // if there is something in the box

        if (box.marbles.Count > 0)
        {
            // pick a random number
            int random = Random.Range(0, box.marbles.Count);

            // set marbleID
            marble = box.marbles[random];
            box.marbles.RemoveAt(random);


            Instantiate(marble, gameObject.transform);
        }

    }
}