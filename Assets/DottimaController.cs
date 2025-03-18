using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DottimaController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Vector2 moveInput = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );
        rb.linearVelocity = moveInput.normalized * speed;

        if (moveInput != Vector2.zero)
        {

            if (moveInput.y > 0)
            {
                animator.Play("CrazyDotUp");
            }
            else if (moveInput.y < 0)
            {
                animator.Play("CrazyDotDown");
            }
            else if (moveInput.x > 0)
            {
                animator.Play("CrazyDotRight");
            }
            else if (moveInput.x < 0)
            {
                animator.Play("CrazyDotLeft");
            }
        }
        else
        {
            animator.Play("CrazyDotIdle");
        }
    }
}