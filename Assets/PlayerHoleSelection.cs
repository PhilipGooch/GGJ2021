using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoleSelection : MonoBehaviour
{
    public Camera camera;
    public GameObject selectedHole;
    public LayerMask ignoreLayer;

    InGameManager gameManager;
    public GameObject marble;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<InGameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public GameObject PlayerChoice() {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                selectedHole = hit.collider.gameObject;
                if (selectedHole.GetComponent<HoleContentsCheck>())
                {
                    // check if the selected hole has a rat with the desired marble

                    HoleContentsCheck holeContentsCheck = selectedHole.GetComponent<HoleContentsCheck>();

                    marble = holeContentsCheck.marble;

                    RatMovement rat = holeContentsCheck.rat;

                    rat.navAgent.SetDestination(rat.innerHolePositions[rat.end]);

                    return selectedHole;
                }
            }
        }
        return null;
    }
}
