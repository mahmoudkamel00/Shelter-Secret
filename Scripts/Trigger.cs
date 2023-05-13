using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public DialogueTrigger trigger;
    public GameObject GameObject;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true) 
        trigger.StartDialogue();
        gameObject.SetActive(false);
    }



}
