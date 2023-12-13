using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Basic Things")]
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    [SerializeField] private GameObject torch;
    Vector3 velocity;
    bool isGrounded;
    [SerializeField] private AudioSource playerSource;
    [SerializeField] private AudioClip torchClip;
    [SerializeField] private Camera playerCam;


    private void Awake()
    {
        playerCam = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1.0f)
        {
            bool isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;

            }

            Movement();
            LightToggle();
        }
    }

    private void Movement()
    {
        float x;
        float z;
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        
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
