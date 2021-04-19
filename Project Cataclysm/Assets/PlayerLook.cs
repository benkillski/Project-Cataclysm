using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("Mouse Settings")]
    public float mouseSensitivityX = 100f;   //X Sensitivity of the mouse
    public float mouseSensitivityY = 100f;   //Y Sensitivity of the mouse
    float xRotation = 0f;

    [Header("Player Body")]
    public Transform playerBody;            //Player's physical body

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   //Locks the mouse to the center of screen so mouse cannot move off screen while in game
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;    //Multplies X Axis by sensitivity
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;    //Multplies Y Axis by sensitivity

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  //Restricts camera from over rotating, locked between -90 degress and 90 degrees on the x axis

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);      //Rotates the camera
        playerBody.Rotate(Vector3.up * mouseX);                             //Rotates the players body with the camera
    }
}
