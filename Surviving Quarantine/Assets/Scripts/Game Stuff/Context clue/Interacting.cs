using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interacting : MonoBehaviour
{
    [SerializeField] private GivingSignal[] signal;
    [SerializeField] private BoredomBar boredomBar;
    [SerializeField] private SideBars bodyFatBar;
    [SerializeField] private SideBars hygieneBar;
    [SerializeField] private TimeOfTheDay tod;

    [SerializeField] private TextMeshProUGUI boredomText;
    [SerializeField] private TextMeshProUGUI hygieneText;
    [SerializeField] private TextMeshProUGUI bodyFatText;
    [SerializeField] private RandomSpawn randomSpawn;


    private float timeToMidnight;
    public float extraTime;


    public void Interaction()
    {
        for(int i = 0; i < signal.Length; i++)
        {
            if (signal[i].onRange && signal[i].cooldown <= 0)
            {
                //subtracting the value
                boredomBar.time -= signal[i].boredomAmountTaken;
                Debug.Log(signal[i].boredomAmountTaken + "Boredom taken");
                bodyFatBar.time += signal[i].bodyFatAmountTaken;
                Debug.Log(signal[i].bodyFatAmountTaken + "Body Fat taken");
                hygieneBar.time += signal[i].hygieneAmountTaken;
                Debug.Log(signal[i].hygieneAmountTaken + "Hygiene taken");
                signal[i].cooldown = signal[i].maxCooldown;
                signal[i].isActive = true;
                signal[i].cooldownCanvasAnim.SetBool("Enable", true);

                if (signal[i].boredomAmountTaken > 0)
                {
                    boredomText.text = "+" + signal[i].boredomAmountTaken.ToString();
                    randomSpawn.CreatingObject(0);
                }
                if (signal[i].bodyFatAmountTaken > 0)
                {
                    bodyFatText.text = "+" + signal[i].bodyFatAmountTaken.ToString();
                    randomSpawn.CreatingObject(1);
                }
                if (signal[i].hygieneAmountTaken > 0)
                {
                    hygieneText.text = "+" + signal[i].hygieneAmountTaken.ToString();
                    randomSpawn.CreatingObject(2);
                }

                if (signal[i].isBed)
                {
                    timeToMidnight = 86400 - tod.time;
                    if (timeToMidnight >= 43200)
                    {
                        tod.time += 43200;
                    }
                    else
                    {
                        tod.time += timeToMidnight;
                        extraTime = 43200 - timeToMidnight;
                    }

                }
            }
        }
    }
}
