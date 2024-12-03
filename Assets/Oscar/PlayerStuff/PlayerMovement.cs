using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform cameraTransform;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public float jumpForce = 5f;
    public float gravityMultiplier = 2f;

    private float turnSmoothVelocity;
    private bool isGrounded;
    private Vector3 movementInput;

    void Start()
    {
        if (!rb) rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movementInput = new Vector3(horizontal, 0f, vertical).normalized;

        if (movementInput.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movementInput.x, movementInput.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        if (movementInput.magnitude >= 0.1f)
        {
            Vector3 moveDirection = Quaternion.Euler(0f, transform.eulerAngles.y, 0f) * Vector3.forward;
            Vector3 targetVelocity = moveDirection * speed;
            rb.linearVelocity = new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z);
        }
        else
        {
            rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f);
        }

        if (!isGrounded)
        {
            rb.AddForce(Physics.gravity * (gravityMultiplier - 1), ForceMode.Acceleration);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}



