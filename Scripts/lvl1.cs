using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvl1 : MonoBehaviour
{
    GameObject key;
    bool foundthekey = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("key"))
        {
            foundthekey = true;
        }
        if (collision.gameObject.CompareTag("teleporter") && foundthekey)
        {
            SceneManager.LoadScene("level2");
        }
    }
}
