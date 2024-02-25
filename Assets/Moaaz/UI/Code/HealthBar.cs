using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    // the following script was built with the help of youtuber Brackeyes
    public Slider slider;
    public void setHealth(int health)
    {
        slider.value = health; 

    }
    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

}
