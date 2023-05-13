using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvl1 : MonoBehaviour
{
    public GameObject key;
    bool foundthekey = false;

    public AudioSource soundource1, soundsource2;
    public AudioClip soundclip1, soundclip2;
    // Start is called before the first frame update
    void Start()
    {
        soundource1.clip = soundclip1;
        soundource1.Play();
        soundource1.loop = true;


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
            key.SetActive(false);
        }
        if (collision.gameObject.CompareTag("teleporter") && foundthekey)
        {
            SceneManager.LoadScene("level2");
        }
    }
    public void musicvolume(float volume)
    {
        soundource1.volume = volume;
    }
}
