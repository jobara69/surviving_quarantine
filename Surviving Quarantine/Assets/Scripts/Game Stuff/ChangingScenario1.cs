using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingScenario1 : MonoBehaviour
{
    [SerializeField] private TimeOfTheDayMenu tod;
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
            anim.SetBool("TimeChange", false);
        }
        else if (time >= 64800)
        {
            anim.SetBool("TimeChange", true);
        }
    }

}
