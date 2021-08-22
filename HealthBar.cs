using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider; //this is the HP slider

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health; //makes sure that the slider starts at the maximum amount of health.
    }


    public void SetHealth(int health)
    {
        slider.value = health; //this will make the slider (HP Bar) be move with the amount of health it current has.


    }
}
