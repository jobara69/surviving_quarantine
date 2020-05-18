using System.Collections;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class TimeOfTheDay : MonoBehaviour
{

    public float time;
    private TimeSpan currenttime;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private Interacting bedInteraction;
    [SerializeField] private RainScript rainScript;
    [SerializeField] private GameObject lightsOnText;
    public int days;
    private int choise;

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
            time = 0 + bedInteraction.extraTime;
            bedInteraction.extraTime = 0;
        }

        if (days % 3 == 0 && days > 0)
        {
            if (!rainScript.wasActive)
            {
                rainScript.enabled = true;
                rainScript.CalculateRain();
            }
        }
        else
        {
            for (int i = 0; i < rainScript.eletricObject.Length; i++)
            {
                rainScript.eletricObject[i].SetActive(true);
            }
            if (rainScript.wasRaining)
            {
                lightsOnText.SetActive(true);
                StartCoroutine(LightsOnEnd());
            }
            rainScript.wasRaining = false;
            rainScript.wasActive = false;
            rainScript.rainParticle.Stop();
            rainScript.isRaining = false;

        }

        currenttime = TimeSpan.FromSeconds(time);
        string[] temptime = currenttime.ToString().Split(":"[0]);
        timeText.text = temptime[0] + ":" + temptime[1];
        dayText.text = days.ToString();
    }

    private IEnumerator LightsOnEnd()
    {
        yield return new WaitForSeconds(2f);
        lightsOnText.SetActive(false);
    }

}
