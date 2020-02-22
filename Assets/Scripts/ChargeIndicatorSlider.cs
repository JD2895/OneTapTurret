using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeIndicatorSlider : MonoBehaviour
{
    private Slider sliderUI;
    private float total = 100;
    private float current = 0;

    void Awake()
    {
        sliderUI = GetComponent<Slider>();
    }

    void Start()
    {
        SetupSlider();
    }

    public void SetSliderValue(float setTo)
    {
        sliderUI.value = setTo;
    }

    private void SetupSlider()
    {
        sliderUI.minValue = 0;
        sliderUI.maxValue = 100;
        sliderUI.wholeNumbers = false;
    }
}
