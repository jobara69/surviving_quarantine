using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using TMPro;

public class TimeOfTheDayMenu : MonoBehaviour
{

    public float time;
    private TimeSpan currenttime;
    [SerializeField] private int days;

    [SerializeField] private int speed;

    void Update()
    {
        ChangeTime();
    }

    public void ChangeTime()
    {
        time += Time.deltaTime * speed;
        if (time > 86400)
        {
            days += 1;
            time = 0;
        }

        currenttime = TimeSpan.FromSeconds(time);
    }

}