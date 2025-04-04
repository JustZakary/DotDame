using UnityEngine;

public class FinishManager : MonoBehaviour
{
    private AudioManager audioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager = Camera.main.GetComponent<AudioManager>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioManager.playSound("completeLevel");
        }
    }
}
