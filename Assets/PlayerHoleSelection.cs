using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoleSelection : MonoBehaviour
{
    public Camera camera;
    public GameObject selectedHole;

    InGameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<InGameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.phase == 3)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    selectedHole = hit.collider.gameObject;
                    if (selectedHole.tag == "Hidy Hole") { 
                        // check if the selected hole has a rat with the desired marble
                    }
                }
            }
        }
    }
}
