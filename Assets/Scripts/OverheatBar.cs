using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverheatBar : MonoBehaviour
{

    public float maxOverheat;
    public float startHue = 130;
    public float overheatHue = 0;
    public Image fill;
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public float GetCurrentOverHeat()
    {
        return slider.value;
    }

    public void SetMaxOverheat(float max)
    {
        slider.maxValue = max;
        slider.value = 0;
    }

    public void SetCurrentOverheat(float delta)
    {
        slider.value += delta;
        float currentHue = (overheatHue - startHue) * (slider.value / slider.maxValue) + startHue;
        fill.color = Color.HSVToRGB(currentHue / 360, 80.0f / 100.0f, 1);
    }
}
