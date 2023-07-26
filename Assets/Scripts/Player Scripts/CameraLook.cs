using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    //Getting all the player info
    public float sensetivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    public GameObject FlashLight;

    // Update is called once per frame
    void LateUpdate()
    {
        //Updating camera location every frame based on player
        CameraMovement();
        FlashLight.transform.localRotation = Quaternion.Euler(xRotation + 90f, 0f, 0f);
    }

    private void CameraMovement()
    {
        float mouseX;
        float mouseY;
        mouseX = Input.GetAxis("Mouse X") * sensetivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensetivity * Time.deltaTime;
       // else
        //{
        //   mouseX = moveStick.Horizontal * sensetivity * Time.deltaTime;
         //   mouseY = moveStick.Vertical * sensetivity * Time.deltaTime;
        //}
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
