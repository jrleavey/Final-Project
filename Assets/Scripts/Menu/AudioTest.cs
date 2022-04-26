using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioTest : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private int firstPlayInt;
    public Slider backgroundSlider, soundEffectsSlider;
    private float backgroundFloat, soundEffectsFloat;



    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt;

        if(firstPlayInt == 0)
        {

        }
        else
        {

        }
    }



}
