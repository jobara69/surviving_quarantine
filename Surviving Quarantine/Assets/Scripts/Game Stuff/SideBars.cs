using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideBars : MonoBehaviour
{
    private float dayTime = 86400f;
    private Image sideFill;
    [SerializeField] private float timeMultiplier = 1;
    public float time;
    [SerializeField] private GameObject normalUI;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator hygieneAnimator;
    [SerializeField] private Animator bodyFatAnimator;
    [SerializeField] private GameObject hygieneBackgroundDying;
    [SerializeField] private GameObject bodyFatBackgroundDying;
    [SerializeField] private bool isHygiene = false;

    private void Start()
    {
         sideFill = GetComponent<Image>();
    }

    private void Update()
    {
        time -= Time.deltaTime * timeMultiplier;
        if (time <= 0)
        {
            //Morre
            time = 86400f;
            normalUI.SetActive(false);
            gameOver.SetActive(true);
            player.SetActive(false);
        }
        if (sideFill.fillAmount <= 0.2)
        {
            if (isHygiene)
            {
                hygieneBackgroundDying.SetActive(true);
                hygieneAnimator.SetBool("IsDying", true);
            }
            else
            {
                bodyFatBackgroundDying.SetActive(true);
                bodyFatAnimator.SetBool("IsDying", true);
            }

        }
        else
        {
            if (isHygiene)
            {
                hygieneBackgroundDying.SetActive(false);
                hygieneAnimator.SetBool("IsDying", false);
            }
            else
            {
                bodyFatBackgroundDying.SetActive(false);
                bodyFatAnimator.SetBool("IsDying", false);
            }
        }
        if (time >= 86400)
        {
            time = 86400;
        }
        sideFill.fillAmount = (time/dayTime);
    }
}
