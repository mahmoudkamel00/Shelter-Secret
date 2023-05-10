using JetBrains.Annotations;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.EventSystems;

public class player_move : MonoBehaviour
{
    public float speed = 5f;
    SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private bool isFacingRight = true;

    public int maxhealth = 100;
    int currentHealth;

    private void Start()
    {
        currentHealth = maxhealth;
        rb = GetComponent<Rigidbody2D>();
    }
     void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 newPosition = transform.position + new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime;

        transform.position = newPosition;

        if (horizontalInput > 0 && !isFacingRight)
        {
            FlipCharacter();
        }
        else if (horizontalInput < 0 && isFacingRight)
        {
            FlipCharacter();
        }
    }
    public void FlipCharacter()
    {
        // Toggle the character's facing direction
        isFacingRight = !isFacingRight;

        // Invert the character's scale along the X-axis to flip horizontally
        transform.Rotate(0f, 180f, 0f);
    }

    public void takedamage(int damage)
    {

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            die();
        }
    }
    public void die()
    {
        //animation die
        Debug.Log("player died");
    }
}
