using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField] private FixedJoystick moveStick;
    public float speed = 12f;
    public float gravity = -9.81f;
    [SerializeField] private bool onPC;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    [SerializeField] private GameObject torch;
    Vector3 velocity;
    bool isGrounded;
    [SerializeField] private AudioSource playerSource;
    [SerializeField] private AudioClip torchClip;
    // Update is called once per frame
    void Update()
    {
        bool isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;

        }

        Movement();
        LightToggle();
    }

    private void Movement()
    {
        float x;
        float z;

        if (onPC)
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
        }

        else
        {
            x = moveStick.Horizontal;
            z = moveStick.Vertical;
        }
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(speed * Time.deltaTime * move);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void LightToggle()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Torch key was pressed.");
            torch.SetActive(!torch.active);
            playerSource.clip = torchClip;
            playerSource.Play();
        }
    }    
}
