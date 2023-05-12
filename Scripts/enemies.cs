using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;

public class enemies : MonoBehaviour
{

    public enum EnemyState
    {
        Idle,
        Chase,
        Attack
    }

   public Animator animator;
    public SpriteRenderer spriteRenderer;

    public EnemyState currentState = EnemyState.Idle;
    public Transform playerTransform;

    public float moveSpeed = 2.0f;
    public float playerenemydiff = 1.0f;

    public int attackDamage = 10;
    public float attackRange = 1.0f;


    public float attackCooldown = 2f;
    private bool canAttack = true;


    public int maxHealth = 50;
    [HideInInspector]public int currentHealth;

   public player_move plmv;
    //public enemies(int attackDamage)
    //{
    //    this.attackDamage = attackDamage;
    //}
    public char BorZ = 'Z';
    [HideInInspector] public bool BossKilled = false;

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
                if (canAttack)
                {
                    Attack();
                    StartCoroutine(AttackCooldown());
                }
                break;
        }
    }

    private void Idle()
    {
        animator.SetBool("idle", true);
        animator.SetBool("attack", false);
        animator.SetBool("run", false);
        if (Vector3.Distance(transform.position, playerTransform.position) <= playerenemydiff)
        {
            currentState = EnemyState.Chase;
        }
    }

    private void Chase()
    {
        //animation
        animator.SetBool("run", true);
        animator.SetBool("idle", false);
        animator.SetBool("attack", false);

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
        // Stop moving
        transform.Translate(Vector2.zero);

        //animation
        animator.SetBool("attack", true);
        animator.SetBool("idle",false);
        animator.SetBool("run",false);

        // Attack the player
        plmv.takedamage(attackDamage);

        //reset
        canAttack = false;

        // Transition back to chase state
        currentState = EnemyState.Chase;
    }
            
    public void takeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            die();
        }
        else
            currentState = EnemyState.Idle;

    }
    public void die()
    {

        // animation
        animator.SetBool("die",true);
        animator.SetBool("idle", false);
        animator.SetBool("attack", false);
        animator.SetBool("run", false);

        // disable enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        //Instantiate(deatheffect, transform.position, Quaternion.identity);
        if (BorZ == 'Z')
        {
            Destroy(gameObject, 1);
        }
        else if (BorZ == 'B') 
        {
            BossKilled = true;
            Destroy(gameObject, 2);
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (plmv != null)
            {
                plmv.takedamage(attackDamage);
            }
        }
        if (collision.gameObject.CompareTag("bullet"))
        {
            currentHealth -= 25;
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

    private System.Collections.IEnumerator AttackCooldown()
    {
        // Wait for the specified cooldown duration
        yield return new WaitForSeconds(attackCooldown);

        // Set the attack flag to true, allowing the enemy to attack again
        canAttack = true;
    }
}

