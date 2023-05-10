using UnityEngine;

public class player_move : MonoBehaviour
{
    public float speed = 5f;
    public Animator animator;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        animator.SetFloat("speed_x", Mathf.Abs(horizontalInput));
        animator.SetFloat("speed_y", Mathf.Abs(verticalInput));
        if ( horizontalInput > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
        }
    
    Vector3 newPosition = transform.position + new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime;
        transform.position = newPosition;

    }
}
