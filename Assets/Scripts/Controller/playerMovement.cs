
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    [Header("Hareket")]
    private float moveSpeed;

    public float walkSpeed;
    public float sprintSpeed;
    public float zeroGravitySpeed;
    public float groundDrag;

    [Header("Zýplama")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Eðilme")]
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;

    [Header("Zemin Kontrol")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public LayerMask whatIsRoof;

    bool grounded;
    bool roofed;
    public bool zeroGravity;
    bool ifRoofed;

    public Transform orientation;
    public Transform flyOrientation;
    public Transform feetOrientation;
    public Transform topOrientation;


    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Vector3 zeroGravityDownDirection;

    Vector3 zeroGravityMoveDirection;

    Vector3 zeroGravityUpDirection;

    Rigidbody rb;

    public MovementState state;
    public enum MovementState
    {
        walking,
        sprinting,
        crouching,
        air,
        fly
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
        zeroGravity = false;
        startYScale = transform.localScale.y;
    }
    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        //if (roofed)
        //    ifRoofed = true; 
        //else 
        //    ifRoofed = false;

        MyInput();
        SpeedControl();
        StateHandler();
        //CrouchPlayer();
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }


    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && readyToJump && grounded && !zeroGravity)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

        if (zeroGravity)
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
        
        else
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);







        //if (Input.GetKeyUp(crouchKey) && !roofed)
        //{
        //    readyToJump = true;
        //    transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        //}
    }

    private void StateHandler()
    {

        //if(Input.GetKey(crouchKey))
        //{
        //    state = MovementState.crouching;
        //    moveSpeed = crouchSpeed;
        //}

        if (zeroGravity)
        {
            state = MovementState.fly;
            moveSpeed = zeroGravitySpeed;
            rb.useGravity = false;
        }
        else if (grounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
        }

        else if (grounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }

        else
        {
            state = MovementState.air;
        }
    }
    private void MovePlayer()
    {

        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        zeroGravityMoveDirection = flyOrientation.forward * verticalInput + flyOrientation.right * horizontalInput;

        zeroGravityDownDirection = feetOrientation.forward * verticalInput + flyOrientation.right * horizontalInput;

        zeroGravityUpDirection = topOrientation.forward * verticalInput + flyOrientation.right * horizontalInput;

        if (zeroGravity && Input.GetKeyDown(KeyCode.LeftControl))
            rb.AddForce(zeroGravityDownDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        else if (zeroGravity && Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(zeroGravityUpDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        else if (zeroGravity)
        {
            rb.AddForce(zeroGravityMoveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            
            if (zeroGravity && Input.GetKey(KeyCode.LeftControl))
                rb.AddForce(zeroGravityDownDirection.normalized * moveSpeed * 10f, ForceMode.Force);

            else if (zeroGravity && Input.GetKey(KeyCode.Space))
                rb.AddForce(zeroGravityUpDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        }
        else if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

    }




    //private void CrouchPlayer()
    //{


    //    roofed = Physics.Raycast(transform.position, Vector3.up, playerHeight * 0.5f + 0.2f, whatIsRoof);

    //    if ((state != MovementState.crouching) && !roofed)
    //    {

    //        transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);

    //    }

    //}

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;

            if (zeroGravity)
                rb.velocity = new Vector3(limitedVel.x, limitedVel.y, limitedVel.z);

            else
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        Debug.Log("Geldi");
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}
