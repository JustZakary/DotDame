using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DottimaController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public Animator animator;
    public GameObject bombPrefab;
    public GameObject arrowPrefab;

    public AudioManager audioManager;
    

    void Start()
    {
        audioManager = Camera.main.GetComponent<AudioManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaceBomb();
        }

        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            SummonArrow();
        }
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

    private void PlaceBomb()
    {
        if (bombPrefab != null)
        {
            Instantiate(bombPrefab, transform.position, Quaternion.identity);
        }
    }

    private void SummonArrow()
    {
        audioManager.playSound("bow");
        if (arrowPrefab != null)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = (mousePosition - transform.position).normalized;

            float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90f;

            GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.Euler(0, 0, angle));
        }
    }
}