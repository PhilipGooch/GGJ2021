using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleContentsCheck : MonoBehaviour
{
    RatMovement rat;
    public GameObject marble;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Rat") {
            rat = other.gameObject.GetComponent<RatMovement>();
            if (rat.reachedBox)
            {
                rat.returned = true;
            }
            if (rat.marble != null) {
                marble = rat.marble;
            }
        }
    }
}
