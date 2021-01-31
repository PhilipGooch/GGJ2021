using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatMovement : MonoBehaviour
{
    public NavMeshAgent navAgent;
    public List<Vector3> holePositions;
    public List<Vector3> innerHolePositions;
    public Vector3 boxPosition;
    public int start;
    public int end;
    Vector3 velocity;
    private BoxContainer box;
    public GameObject marble;
    public GameObject marbleMount;
    public bool returned;
    InGameManager gameManager;
    public bool reachedBox = false;
    public Vector4 asdf;

    void Start()
    {
        returned = false;

        box = FindObjectOfType<BoxContainer>();

        boxPosition = Vector3.zero;

        holePositions = new List<Vector3>();
        holePositions.Add(new Vector3(-250, 0, 0));
        holePositions.Add(new Vector3(-250, 0, 100));
        holePositions.Add(new Vector3(-250, 0, 200));
        holePositions.Add(new Vector3(-200, 0, 250));
        holePositions.Add(new Vector3(-100, 0, 250));
        holePositions.Add(new Vector3(0, 0, 250));
        holePositions.Add(new Vector3(100, 0, 250));
        holePositions.Add(new Vector3(200, 0, 250));
        holePositions.Add(new Vector3(250, 0, 200));
        holePositions.Add(new Vector3(250, 0, 100));
        holePositions.Add(new Vector3(250, 0, 0));

        innerHolePositions = new List<Vector3>();
        innerHolePositions.Add(new Vector3(-280, 0, 0));
        innerHolePositions.Add(new Vector3(-280, 0, 100));
        innerHolePositions.Add(new Vector3(-280, 0, 200));
        innerHolePositions.Add(new Vector3(-200, 0, 280));
        innerHolePositions.Add(new Vector3(-100, 0, 280));
        innerHolePositions.Add(new Vector3(0, 0, 280));
        innerHolePositions.Add(new Vector3(100, 0, 280));
        innerHolePositions.Add(new Vector3(200, 0, 280));
        innerHolePositions.Add(new Vector3(280, 0, 200));
        innerHolePositions.Add(new Vector3(280, 0, 100));
        innerHolePositions.Add(new Vector3(280, 0, 0));

        gameManager = FindObjectOfType<InGameManager>();
    }

    void Update()
    {
        asdf = navAgent.destination;
        if (gameManager.gameStarted && !reachedBox)
        {
            navAgent.SetDestination(boxPosition);
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
            if (box.ratIDs.Contains(start))
            {
                // pick a random number
                int random = Random.Range(0, box.marbles.Count);

                // set marbleID
                marble = box.marbles[random];
                box.marbles.RemoveAt(random);

                marble = Instantiate(marble, marbleMount.transform);
            }
        }

    }
}