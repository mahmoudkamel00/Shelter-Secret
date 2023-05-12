using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    public Slider musicslider;
    public void musicvolume()
    {
        GetComponent<lvl2>().musicvolume(musicslider.value);
        GetComponent<lvl1>().musicvolume(musicslider.value);

    }
}
