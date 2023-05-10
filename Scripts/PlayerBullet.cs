using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public Transform player;
    public int damage = 25;


    private void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void Update()
    {
        //bullet();
    }

    private void OnTriggerEnter(Collider other)
    {
        enemies zombie = other.GetComponent<enemies>();
        if (zombie != null)
        {
            zombie.takeDamage(damage);
        }
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6 || collision.gameObject.CompareTag("enemy"))
        {
            collision.gameObject.GetComponent<enemies>().takeDamage(25);
            Destroy(gameObject);
        }
    }
    void bullet()
    { 
            transform.position += transform.right * Time.deltaTime * speed;

    }
}
