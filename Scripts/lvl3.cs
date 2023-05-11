using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl3 : MonoBehaviour
{
    bool BossKilled = false;
    GameObject collider;
    Animator animator;

    public PlayerBullet bullet;
    public Transform launchOffset;

    float nextAttackTime = 0;
    public float attackRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
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
                animator.SetTrigger("attack");
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("collider") && BossKilled)
        {
            collider.SetActive(false);
        }
    }
}
