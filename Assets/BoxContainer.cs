using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxContainer : MonoBehaviour
{
    public List<GameObject> marbles;
    private List<int> possibleRatIDs = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    public List<int> ratIDs = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 6; i++)
        {
            int random = Random.Range(0, possibleRatIDs.Count);
            ratIDs.Add(possibleRatIDs[random]);
            possibleRatIDs.RemoveAt(random);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
