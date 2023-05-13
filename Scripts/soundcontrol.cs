using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class soundcontrol : MonoBehaviour
{
    public Slider theVolume;
    public AudioMixer mixer;
    // Start is called before the first frame update
   

    // Update is called once per frame
   private void Update()
    {
        mixer.SetFloat("Volume", theVolume.value);
    }
    public void Setsound(float sound)
    {
         mixer.SetFloat("Volume", sound);
    }
}
