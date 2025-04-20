using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveTowardsPlayer : MonoBehaviour
{
    public float speed = 5f; // Speed at which objects move toward the player
    public AudioClip coinSound;   // Assign coin sound in the Inspector
    public AudioClip enemySound;  // Assign enemy sound in the Inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get AudioSource component
    }

    void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime; // Move towards player
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " collided with " + other.gameObject.name); // Debugging

        if (other.CompareTag("Player"))
        {
            if (CompareTag("Enemy"))
            {
                Debug.Log("Enemy hit the player! Restarting game...");
                PlaySound(enemySound); // Play enemy collision sound
                Invoke("RestartGame", 0.5f); // Delay restart to allow sound to play
            }
            else if (CompareTag("Coin"))
            {
                Debug.Log("Coin collected!");
                PlaySound(coinSound); // Play coin collection sound
                CoinManager.instance.AddCoin(); // Increase coin count
                Destroy(gameObject, 0.2f); // Destroy coin after sound plays
            }
        }
    }

    void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip); // Play sound effect
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart the game
    }
}
