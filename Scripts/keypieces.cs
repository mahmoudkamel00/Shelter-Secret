using UnityEngine;

public class keypieces : MonoBehaviour
{
    public lvl2 gameManager; // Reference to the game manager

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Disable the key piece GameObject
            gameObject.SetActive(false);

            // Notify the game manager that a key piece has been collected
            gameManager.KeyPieceCollected();
        }
    }
}