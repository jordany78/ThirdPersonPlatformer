using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 5f;
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;
    public int maxJumps = 2;

    private Rigidbody rb;
    private bool isGrounded;
    private int jumpsRemaining;
    private bool isDashing;
    private float dashEndTime;

    public Transform cameraTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpsRemaining = maxJumps;
    }

    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        if (isGrounded)
        {
            jumpsRemaining = maxJumps;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 movement = forward * moveZ + right * moveX;

        if (!isDashing)
        {
            rb.linearVelocity = new Vector3(movement.x * moveSpeed, rb.linearVelocity.y, movement.z * moveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                jumpsRemaining--;
            }
            else if (jumpsRemaining > 0)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                jumpsRemaining--;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            StartDash(movement);
        }

        if (isDashing && Time.time >= dashEndTime)
        {
            isDashing = false;
        }
    }

    void StartDash(Vector3 direction)
    {
        isDashing = true;
        dashEndTime = Time.time + dashDuration;

        rb.linearVelocity = new Vector3(direction.x * dashSpeed, rb.linearVelocity.y, direction.z * dashSpeed);
    }
}