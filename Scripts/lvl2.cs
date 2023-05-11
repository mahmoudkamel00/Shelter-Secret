using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvl2 : MonoBehaviour
{
    Animator animator;

    public PlayerBullet bullet;
    public Transform launchOffset;

    float nextAttackTime = 0;
    public float attackRate = 1f;

    public int totalKeyPieces = 3; // Total number of key pieces required
    private int collectedKeyPieces = 0; // Counter for collected key pieces
    bool nextLevel = false;

    public Sprite transformedSprite;
    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (Time.time >= nextAttackTime) //to make the player doesn't attack consecutive, using time
            {
                //animator.SetTrigger("attack");
                Instantiate(bullet, launchOffset.position, transform.rotation);
                nextAttackTime = Time.time + attackRate;

            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("teleporter") && nextLevel)
        {
            SceneManager.LoadScene("Level2");
        }
        if (collision.gameObject.CompareTag("armor"))
        {
            spriteRenderer.sprite = transformedSprite;
        }
        //if (collision.gameObject.layer == 6)
        //{
        //    //damage player
        //}
    }


    // Call this function when a key piece is collected
    public void KeyPieceCollected()
    {
        collectedKeyPieces++;

        // Check if all key pieces have been collected
        if (collectedKeyPieces >= totalKeyPieces)
        {
            // All key pieces collected, load the next level
            nextLevel = true;
        }
    }
}
