using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float radius = 5f; // Custom radius to check for objects
    public SpriteRenderer spriteRenderer; // Reference to the sprite renderer
    
    public AudioManager audioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager = Camera.main.GetComponent<AudioManager>();
        // Start the coroutine to wait and destroy objects
        StartCoroutine(ExplodeAfterDelay());
    }

    private System.Collections.IEnumerator ExplodeAfterDelay()
    {
        audioManager.playSound("fuse"); // Play the bow sound
        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);
        // Play the explosion sound
        audioManager.playSound("explosion");

        // Find all objects with the tag "Block"
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");

        //Turn off the sprite renderer
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }

        foreach (GameObject block in blocks)
        {
            // Check if the block is within the specified radius
            if (Vector3.Distance(transform.position, block.transform.position) <= radius)
            {
                Destroy(block); // Destroy the block
            }
        }

        //wait for 1 second
        yield return new WaitForSeconds(3f);
        // Optionally destroy the bomb itself
        Destroy(gameObject);
    }
}
