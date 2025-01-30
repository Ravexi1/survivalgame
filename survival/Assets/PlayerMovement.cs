using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    public float speed;
    private Vector2 moveInput;

    [SerializeField] private Rigidbody2D rb;
    public Animator animator;

    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }
    void FixedUpdate()
    {
        // Применяем движение через Rigidbody2D
        rb.linearVelocity = moveInput * speed;
    }


}
