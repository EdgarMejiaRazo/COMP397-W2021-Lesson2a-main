using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    //public float movementForce;
    //public float jumpForce;
    public Rigidbody rigidBody;
    public bool isGrounded;
    public float maxSpeed = 10.0f;
    public float gravity = -30.0f;
    public float jumpHeight = 3.0f;

    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public LayerMask groundMask;

    public CharacterController controller;

    public Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        //rigidBody = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
       
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask); //Detect if Im grounded or not

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * maxSpeed * Time.deltaTime);

        if (Input.GetButton("Jump") && isGrounded)
    {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
    }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //if(isGrounded)
        //{
        //    if (Input.GetAxisRaw("Horizontal") > 0)
        //    {
        //        //move right
        //        rigidBody.AddForce(Vector3.right * movementForce);

        //    }

        //    if (Input.GetAxisRaw("Horizontal") < 0)
        //    {
        //        //move right
        //        rigidBody.AddForce(Vector3.left * movementForce);

        //    }

        //    if (Input.GetAxisRaw("Vertical") > 0)
        //    {
        //        //move right
        //        rigidBody.AddForce(Vector3.forward * movementForce);

        //    }

        //    if (Input.GetAxisRaw("Vertical") < 0)
        //    {
        //        //move right
        //        rigidBody.AddForce(Vector3.back * movementForce);

        //    }

        //    if (Input.GetAxisRaw("Jump") > 0)
        //    {
        //        //move right
        //        rigidBody.AddForce(Vector3.up * jumpForce);

        //    }


        //}


    }

    //private void OnCollisionEnter(Collision other)
    //{
    //    if(other.gameObject.CompareTag("Ground"))
    //    {
    //        isGrounded = true;
    //    }

    //}

    //private void OnCollisionStay(Collision other)
    //{
    //    if (other.gameObject.CompareTag("Ground"))
    //    {
    //        isGrounded = true;
    //    }
    //}

    //private void OnCollisionExit(Collision other)
    //{
    //    if (other.gameObject.CompareTag("Ground"))
    //    {
    //        isGrounded = false;
    //    }

    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
}
