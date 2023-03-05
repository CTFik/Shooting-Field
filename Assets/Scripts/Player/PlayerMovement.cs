using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // VARIABLES
    public CharacterController characterController;
    public float speed = 10f;
    
    public float gravity = -9.81f;
    Vector3 velocity;

    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundMask;
    bool isGrounded;

    public float jumpHeight = 3f;

    // UPDATE
    void Update()
    {

        //Movimiento Player
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);

        //Salto
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        //Gravedad
        characterController.Move(velocity * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;

        //Detectar Suelo
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }


    }
}
