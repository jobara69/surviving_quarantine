using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingScenario : MonoBehaviour
{
    [SerializeField] private TimeOfTheDay tod;
    [SerializeField] private RainScript rainState;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float time = tod.time;
        if (time >= 18000 && time < 64800)
        {
            if (rainState.isRaining)
            {
                anim.SetBool("IsRaining", true);
            }
            else
            {
                anim.SetBool("TimeChange", false);
                anim.SetBool("IsRaining", false);
            }
        }
        else if (time >= 64800 || time < 18000)
        {
            if (rainState.isRaining)
            {
                anim.SetBool("IsRaining", true);
            }
            else
            {
                anim.SetBool("TimeChange", true);
                anim.SetBool("IsRaining", false);
            }
        }
    }

}
