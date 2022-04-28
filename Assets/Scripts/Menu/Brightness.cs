using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brightness : MonoBehaviour
{

    public Slider GammaSlider;
    public float sliderValue;
    public Light sceneLight;
    // Start is called before the first frame update
    public void Start()
    {
        GammaSlider.value = PlayerPrefs.GetFloat("Brightness", sliderValue);
    }

    // Update is called once per frame
    void Update()
    {
        sceneLight.intensity = GammaSlider.value;
        PlayerPrefs.SetFloat("Brightness", sliderValue);
    }

    public void updateBrightness(float value)
    {
        sliderValue = value;
    }

}
