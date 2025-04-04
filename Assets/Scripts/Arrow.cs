using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 10f; // Speed of the arrow
    private AudioManager audioManager;

    void Update()
    {
        // Move the arrow forward in the direction of its current angle
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        audioManager = Camera.main.GetComponent<AudioManager>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object hit has the "Killable" tag
        Debug.Log("Hit object tag: " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Killable"))
        {
            // Play the hit sound
            audioManager.playSound("robotHurt");
            // Destroy the arrow and the object it hit
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (!collision.gameObject.CompareTag("Player"))
        {
            speed = 0; // Stop the arrow
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject, 5f);
        }
    }
}
