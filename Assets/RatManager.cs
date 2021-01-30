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
    private int ratID = 0;

    void Start()
    {
        
    }

    public void ReleaseRats()
    {
        released = true;
    }

    void Update()
    {
        if (released)
        {
            timer += Time.deltaTime;
            if (timer > nextRelease)
            {
                if (ratID < 11)
                {
                    RatMovement ratMovement = rats[ratID].GetComponent<RatMovement>();
                    ratMovement.navAgent.SetDestination(ratMovement.boxPosition);
                    nextRelease += delay;
                    ratID++;
                }
            }
        }
    }
    public void ResetRats()
    {
        ratID = 0;
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
