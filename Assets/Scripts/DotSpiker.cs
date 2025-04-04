using UnityEngine;

public class DotSpiker : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Animator animator;
    public int direction = 1; // 0: down, 1: left, 2: up, 3: right
    private Vector2 dirVector;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.Play("SpikerSpin");
    }

    private void FixedUpdate()
    {
        if (direction == 0) dirVector = new Vector2(0.0f, -1.0f); // Down
        else if (direction == 1) dirVector = new Vector2(-1.0f, 0.0f); // Left
        else if (direction == 2) dirVector = new Vector2(0.0f, 1.0f); // Up
        else if (direction == 3) dirVector = new Vector2(1.0f, 0.0f); // Right
        Vector2 velocity = dirVector.normalized * speed;
        rb.linearVelocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (direction == 0) direction = 2; // Change direction to up
        else if (direction == 1) direction = 3; // Change direction to right
        else if (direction == 2) direction = 0; // Change direction to down
        else if (direction == 3) direction = 1; // Change direction to left
        // Change direction on collision
        Vector2 newPos = new Vector2(
            transform.position.x - dirVector.x * 0.1f,
            transform.position.y - dirVector.y * 0.1f
        );
        rb.MovePosition(newPos);
  }
}
