using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class healthbar : MonoBehaviour
{
    public Slider slider;
    public void setmaxhealth(int max)
    {
        slider.maxValue = max;
        slider.value = max;
    }
    public void sethealth(int health)
    {
        slider.value = health;
    }
}
