using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatManager : MonoBehaviour
{
    public List<GameObject> rats;
    public float delay;
    private float nextRelease = 0;

    public float timer = 0;
    private bool released = false;
    private int ratIDIndex = 0;
    private List<int> possibleRatIDs = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    public List<int> ratIDs = new List<int>();

    void Start()
    {
        
    }

    public void ReleaseRats()
    {
        possibleRatIDs = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        ratIDs = new List<int>();

        for (int i = 0; i < 11; i++)
        {
            int random = Random.Range(0, possibleRatIDs.Count);
            ratIDs.Add(possibleRatIDs[random]);
            possibleRatIDs.RemoveAt(random);
        }
        released = true;
    }

    void Update()
    {
        
        if (released)
        {
            timer += Time.deltaTime;
            if (timer > nextRelease)
            {
                if (ratIDIndex < 11)
                {
                    RatMovement ratMovement = rats[ratIDs[ratIDIndex]].GetComponent<RatMovement>();
                    ratMovement.navAgent.SetDestination(ratMovement.boxPosition);
                    nextRelease += delay;
                    ratIDIndex++;
                }
            }
        }
    }
    public void ResetRats()
    {
        ratIDIndex = 0;
        released = false;
        timer = 0;
        nextRelease = 0;
        for(int i = 0; i < 11; i++)
        {
            RatMovement ratMovement = rats[i].GetComponent<RatMovement>();
            Destroy(ratMovement.marble, 0f);
        }
    }


    //To Do:
    //check all rats get back - to set game manger to next phase
}
