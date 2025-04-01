using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharMoving : MonoBehaviour
{
    public Rigidbody rb;

    private float speed = 6.0f;
    public float walkSpeed;
    public float sprintSpeed;

    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode jumpKey = KeyCode.Space;

    public MoveState state;
    public enum MoveState 
    {
        walking,
        sprinting,
        air
    }

    private void Start()
    {
        readyToJump = true;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float deltaY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(deltaX, 0, deltaY);

        StateHandler();

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight* 0.5f + 0.2f);
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else 
        { 
            rb.drag = 0;    
        }

        if (Input.GetKey(jumpKey) && readyToJump && grounded) 
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
        //Debug.Log(grounded);
        //Debug.Log(readyToJump);
    }

    private void Jump() 
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        Debug.Log("jump");
    }
    private void ResetJump() 
    {
        readyToJump = true;
    }
    private void StateHandler() 
    {
        if (grounded && Input.GetKey(sprintKey))
        {
            state = MoveState.sprinting;
            speed = sprintSpeed;
        }
        else if (grounded)
        {
            state = MoveState.walking;
            speed = walkSpeed;
        }
        else 
        {
            state = MoveState.air;
        }
    }

}
