using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;         //Player's Character Controller component

    [Header("Movement Settings")]
    [SerializeField] float speed = 6f;                  //Movement Speed
    [SerializeField] const float GRAVITY = -9.8f;       //Gravity Rate
    [SerializeField] float jumpHeight = 2f;             //Jump power

    [Header("Ground Checking")]
    [SerializeField] float groundDistance = 0.4f;       //Distance from origin to the ground
    [SerializeField] LayerMask groundMask;              //Ground Layer
    bool isGrounded;                                    //Tells if player is grounded or not

    Vector3 velocity;                                   //Velocity of Player

    /*void Awake()
    {
        GameManager.instance.AutoSave();
    }*/

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();   //Assigns the CharacteController component to controller
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    //Handles player movements
    void PlayerMovement()
    {
        isGrounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - GetComponent<CharacterController>().bounds.extents.y, transform.position.z), groundDistance, groundMask);     //Checks area below player if there is ground

        //If grounded and the player's y velocity is negative
        if (isGrounded && velocity.y <= 0)
        {
            velocity.y = -2f;   //Sets y velocity to -2 instead of 0 to have player stay on ground when grounded
        }

        float x = Input.GetAxis("Horizontal");  //Movement on X Axis (between -1 and 1, -1 is moving left, 0 is not moving, 1 is moving right)
        float z = Input.GetAxis("Vertical");    //Movement on Z Axis (between -1 and 1, -1 is moving back, 0 is not moving, 1 is moving forward)

        Vector3 move = transform.right * x + transform.forward * z;     //Combined Movement  


        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Player Running");
            speed = 10f;
        }
        else
        {
            Debug.Log("Player Walking");
            speed = 6f;
        }
        controller.Move(move * speed * Time.deltaTime);                 //Moves player, multiplies the movement by the Player's speed

        //If the Jump button is pressed and the player is on the ground
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * GRAVITY);    //Jumps the player
        }

        velocity.y += GRAVITY * Time.deltaTime;         //Change the player's Y velocity by the rate of Gravity

        controller.Move(velocity * Time.deltaTime);     //Moves the player on the Y Axis
    }

    public Vector3 GetPlayerVelocity()
    {
        return velocity;
    }

    //Method called when player dies
    /*void KillPlayer()
    {
        GameManager.instance.LoadDeathScreen();
    }*/
}
