using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvl2 : MonoBehaviour
{
    public Animator animator;

    public PlayerBullet bullet;
    public Transform launchOffset;

    float nextAttackTime = 0;
    public float attackRate = 1f;

    public int totalKeyPieces = 3; // Total number of key pieces required
    private int collectedKeyPieces = 0; // Counter for collected key pieces
    bool nextLevel = false;

    public Sprite transformedSprite;
    private SpriteRenderer spriteRenderer;
    public bool armorsuit = false;
    public GameObject armor;

    [HideInInspector]public Vector3 respawnpoint;

  

    public AudioSource soundsource1;
    public AudioClip soundclip1;

    bool lvl3 = false;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        respawnpoint = transform.position;
        if (lvl3)
        {
            soundsource1.Stop();
        }
        else
        {
            soundsource1.clip = soundclip1;
            soundsource1.Play();
            soundsource1.loop = true;
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        if (armorsuit)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (Time.time >= nextAttackTime) //to make the player doesn't attack consecutive, using time
                {
                    animator.SetBool("attack", true);
                    //animator.SetTrigger("attack");
                    Instantiate(bullet, launchOffset.position, transform.rotation);
                    nextAttackTime = Time.time + attackRate;
                   
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("teleporter") && nextLevel)
        {
            SceneManager.LoadScene("level3");
            lvl3 = true;
            spriteRenderer.sprite = transformedSprite;
            animator.SetBool("diler", true);
        }
        if (collision.gameObject.CompareTag("armor"))
        {
            spriteRenderer.sprite = transformedSprite;
            armorsuit = true;
            armor.SetActive(false);
        }
        if (collision.gameObject.CompareTag("checkpoint"))
        {
            respawnpoint = transform.position;
        }
    }

    public void updaetcheckpoint(Vector2 pos)
    {
        respawnpoint = pos;
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
    private System.Collections.IEnumerator cooldown()
    {
        // Wait for the specified cooldown duration
        yield return new WaitForSeconds(1);

        // Set the attack flag to true, allowing the enemy to attack again
        
    }
   
    public void musicvolume(float volume)
    {
        soundsource1.volume = volume;
    }
}
