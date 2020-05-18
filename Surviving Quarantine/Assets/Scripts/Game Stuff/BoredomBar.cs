using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BoredomBar : MonoBehaviour
{
    private float dayTime = 86400f;
    private Slider boredomBar;
    public float timeMultiplier = 1;
    public float time;
    [SerializeField] private TimeOfTheDay tod;
    [SerializeField] private GameObject normalUI;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject player;
    private Animator boredomAnim;
    [SerializeField] private GameObject backgroundDying;


    private void Start()
    {
        boredomBar = GetComponent<Slider>();
        boredomAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        time += Time.deltaTime * timeMultiplier;

        
        if (time > dayTime)
        {
            //Morre
            time = 0;
            normalUI.SetActive(false);
            gameOver.SetActive(true);
            player.SetActive(false);
        }
        if (time <= 0)
        {
            time = 0;
        }
        boredomBar.value = time / dayTime;

        if (boredomBar.value >= 0.8)
        {
            backgroundDying.SetActive(true);
            boredomAnim.SetBool("IsDying", true);
        }
        else
        {
            backgroundDying.SetActive(false);
            boredomAnim.SetBool("IsDying", false);
        }

         
        if (tod.days % 2 == 0 && tod.days <= 40f && tod.days > 0)
        {
            timeMultiplier += 0.01f;
        }
    }
}
