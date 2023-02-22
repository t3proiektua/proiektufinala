using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public Text time;
    private float time_Seconds;

    void Update()
    {
        time_Seconds = float.Parse(time.text) + Time.deltaTime; //pasatu diren segunduak kalkulatuko ditu
        time.text = time_Seconds.ToString(); //textua gordetzen duen elementuari erantsiko dio
    }
}
