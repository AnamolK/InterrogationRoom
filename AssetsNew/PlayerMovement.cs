using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f; // This should appear in the Inspector

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        // Get the Rigidbody2D component attached to this GameObject
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on " + gameObject.name + ". Please add one.");
        }
    }

    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        float moveY = Input.GetAxisRaw("Vertical");   // W/S or Up/Down

        moveInput = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        // If rb is null, exit early
        if (rb == null)
            return;

        rb.velocity = moveInput * moveSpeed;
    }
}
