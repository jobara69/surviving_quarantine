using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cellphone : MonoBehaviour
{
    public float cooldown;
    public float maxCooldown;
    public float boredomAmountTaken;
    public float bodyFatAmountTaken;
    public float hygieneAmountTaken;

    [SerializeField] private float multiplier;
    [SerializeField] private BoredomBar boredomBar;
    [SerializeField] private SideBars bodyFatBar;
    [SerializeField] private SideBars hygieneBar;
    [SerializeField] Animator cellphoneAnim;
    [SerializeField] TextScriptPhone[] texts; 

    private bool isActive = false;
    private float timeCanBePressed = 5;
    [SerializeField] private float time = 0;


    private void Update()
    {
        if (isActive)
        {
            cooldown -= Time.deltaTime * multiplier;
        }
        if (cooldown <= 0)
        {
            isActive = false;
            cellphoneAnim.SetBool("Enable", false);
        }
    }

    public void Interaction()
    {
        if (cooldown <= 0)
        {
            boredomBar.time -= boredomAmountTaken;
            Debug.Log(boredomAmountTaken + "Boredom taken");
            bodyFatBar.time += bodyFatAmountTaken;
            Debug.Log(bodyFatAmountTaken + "Body Fat taken");
            hygieneBar.time += hygieneAmountTaken;
            Debug.Log(hygieneAmountTaken + "Hygiene taken");

            if (boredomAmountTaken > 0)
            {
                for (int i = 0; i < texts.Length; i++)
                {
                    texts[i].enabled = true;
                    texts[i].SpawnObject();
                }
            }

            isActive = true;
            cellphoneAnim.SetBool("Enable", true);
            time += Time.deltaTime;
            if (time >= 5)
            {
                time = 0;
                cooldown = maxCooldown;
            }
        }
    }
}
