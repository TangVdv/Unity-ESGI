using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    private float moveSpeed;
    public float walkSpeed = 5f;
    public float sprintSpeed = 10f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private bool hasMinimumStaminaToRun = true;

    Player playerScript;

    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        playerScript = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
         
        if (Input.GetKey(KeyCode.LeftShift) && playerScript.currentStamina > 0 && hasMinimumStaminaToRun)
        {
            moveSpeed = sprintSpeed;
            playerScript.SetStamina(-.05f);      
        }
        else
        { 
            moveSpeed = walkSpeed;
            if(playerScript.currentStamina < playerScript.maxStamina)
            {
                playerScript.SetStamina(.01f);
                if(playerScript.currentStamina >= 20)
                {
                    hasMinimumStaminaToRun = true;
                }
                else
                {
                    hasMinimumStaminaToRun = false;
                }
            }
        }

        controller.Move(move * moveSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
