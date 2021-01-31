using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxContainer : MonoBehaviour
{
    public List<GameObject> marbles;
    public List<GameObject> initialMarbles;
    public List<GameObject> tempMarbles;
    private List<int> possibleRatIDs = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    public List<int> ratIDs = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PopulateBox(int numMarbles) {

        tempMarbles.Clear();
        marbles.Clear();
        for(int i = 0; i < initialMarbles.Count; i++)
        {
            tempMarbles.Add(initialMarbles[i]);
        }

        for (int i = 0; i < numMarbles; i++)
        {
            int random = Random.Range(0, tempMarbles.Count);
            marbles.Add(tempMarbles[random]);
            tempMarbles.RemoveAt(random);
        }


        possibleRatIDs = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        for (int i = 0; i < numMarbles; i++)
        {
            int random = Random.Range(0, possibleRatIDs.Count);
            ratIDs.Add(possibleRatIDs[random]);
            possibleRatIDs.RemoveAt(random);
        }
    }
}
