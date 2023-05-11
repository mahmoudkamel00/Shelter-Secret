using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    lvl2 gamecontroller;

    private void Awake()
    {
        gamecontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<lvl2>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gamecontroller.updaetcheckpoint(transform.position);
        }
    }
}
