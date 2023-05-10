using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enemies : MonoBehaviour
{

    public enum EnemyState
    {
        Idle,
        Chase,
        Attack
    }

    Animator animator;
    SpriteRenderer spriteRenderer;

    public EnemyState currentState = EnemyState.Idle;
    public Transform playerTransform;

    public float moveSpeed = 2.0f;
    public float playerenemydiff = 1.0f;

    public float attackDamage = 10.0f;
    public float attackRange = 1.0f;

    public float nextAttackRate = 2f;
    float timeSinceLastAttack = 0f;

    public int maxHealth = 50;
    int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        switch (currentState)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Chase:
                Chase();
                break;
            case EnemyState.Attack:
                Attack();
                break;
        }
    }

    private void Idle()
    {
        animator.SetTrigger("idle");
        if (Vector3.Distance(transform.position, playerTransform.position) <= playerenemydiff)
        {
            currentState = EnemyState.Chase;
        }
    }

    private void Chase()
    {
        //animation
        animator.SetTrigger("run");

        //transfrom flip X
        if (Vector3.Distance(playerTransform.position, transform.position) > 0.01f)
        {
            if (playerTransform.position.x > transform.position.x)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }


        //moving
        Vector2 direction = playerTransform.position - transform.position;
        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, playerTransform.position) < attackRange)
        {
            currentState = EnemyState.Attack;
        }
        if (Vector3.Distance(playerTransform.position, transform.position) > playerenemydiff)
        {
            currentState = EnemyState.Idle;
        }
    }

    private void Attack()
    {
        transform.Translate(Vector2.zero);

        if (timeSinceLastAttack >= nextAttackRate)
        {
            // Reset the timer
            timeSinceLastAttack = 0f;
            // Stop moving

            //animation
            animator.SetTrigger("attack");


            // Attack the player

            //playerTransform.GetComponent<PlayerHealth>().TakeDamage(attackDamage);


            // Transition back to chase state
            currentState = EnemyState.Chase;
        }
        else
            timeSinceLastAttack += Time.deltaTime;
    }
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetBool("idle", false);
        animator.SetBool("run", false);
        animator.SetBool("attack", false);
        animator.SetBool("die", false);
        animator.SetBool("damage", true);

        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            die();
        }
        else
            currentState = EnemyState.Idle;

    }
    void die()
    {
        Debug.Log("enemy died");
        // animation
        animator.SetTrigger("die");

        // disable enemy
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        this.enabled = false;
        //Destroy(gameObject,2);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //GetComponent<PlayerHealth>().TakeDamage(10);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            currentState = EnemyState.Idle;
            Debug.Log("out");
        }
    }
}