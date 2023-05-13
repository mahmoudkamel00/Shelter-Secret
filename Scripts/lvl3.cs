using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvl3 : MonoBehaviour
{
    public GameObject collider;
    private SpriteRenderer spriteRenderer;
    [HideInInspector] public Vector3 respawnpoint;

    public AudioSource soundsource1, soundsource2;
    public AudioClip soundclip1, soundclip2;
    // Start is called before the first frame update
    void Start()
    {
        soundsource1.clip = soundclip1;
        soundsource1.Play();
        soundsource1.loop = false;

        soundsource2.clip = soundclip2;
        soundsource2.PlayDelayed(soundclip1.length);
        soundsource2.loop = true;

        spriteRenderer = GetComponent<SpriteRenderer>();
        respawnpoint = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if ( Time.time > 60 )
        {
            collider.GetComponent<BoxCollider2D>().enabled = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("checkpoint"))
        {
            respawnpoint = transform.position;
        }
        if (collision.gameObject.CompareTag("win"))
        {
            SceneManager.LoadScene("victory");
        }
    }
    public void updaetcheckpoint(Vector2 pos)
    {
        respawnpoint = pos;
    }
    public void musicvolume(float volume)
    {
        soundsource1.volume = volume;
        soundsource2.volume = volume;

    }
}
