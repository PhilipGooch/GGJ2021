using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDirection : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    public GameObject player;

    float xRotation; 
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //float x = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //float y = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //xRotation -= y;
        //xRotation = Mathf.Clamp(xRotation, -90f, 90);

        //transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //player.transform.Rotate(Vector3.up * x);
    }
}
