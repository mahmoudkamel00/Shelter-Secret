using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public AudioSource soundsource1;
    public AudioClip soundclip1;

    private void Start()
    {
        soundsource1.clip = soundclip1;
        soundsource1.Play();
        soundsource1.loop = false;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        soundsource1.Stop();
    }
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
    public void musicvolume(float volume)
    {
        soundsource1.volume = volume;
    }
}
