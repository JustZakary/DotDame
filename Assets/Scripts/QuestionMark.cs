using UnityEngine;

public class QuestionMark : MonoBehaviour
{
    public AudioManager audioManager;
    
    private void Start()
    {
        audioManager = Camera.main.GetComponent<AudioManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioManager.playSound("grabItem");
        if (collision.gameObject.name == "CrazyDot")
        {
            Destroy(gameObject);
        }
    }
}
