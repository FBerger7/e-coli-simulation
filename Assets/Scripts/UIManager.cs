using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static int globalBacteriaCount = 1;
    public TMP_Text eColiBacteriaCount;
    public TMP_Text simulationTimeValue;
    public TMP_Text temperatureValue;
    public Slider temperatureSlider;

    private float time;


    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        //eColiBacteriaCount.text = GameObject.FindGameObjectsWithTag("EColi").Length.ToString();
        eColiBacteriaCount.text = globalBacteriaCount.ToString();
        TimeSpan timeSpan = TimeSpan.FromSeconds(Time.time);
        simulationTimeValue.text = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 1)
        {
            //eColiBacteriaCount.text = GameObject.FindGameObjectsWithTag("EColi").Length.ToString();
            eColiBacteriaCount.text = globalBacteriaCount.ToString();
            time = 0;
        }           
        TimeSpan timeSpan = TimeSpan.FromSeconds(Time.time);
        simulationTimeValue.text = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        temperatureValue.text = String.Format("{0:0.#}", temperatureSlider.value) + "°C";
    }
}
