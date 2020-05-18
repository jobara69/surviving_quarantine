using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GivingSignal : MonoBehaviour
{
    [SerializeField] private InteractablesAsset interactablesAsset;
    [SerializeField] private Image iconBox;
    [SerializeField] private Image Icon;
    [SerializeField] private Animator iconBoxAnim;
    [SerializeField] private TextMeshProUGUI cooldownText;
    public Animator cooldownCanvasAnim;
    [SerializeField] private float timeMultiplier;
    public float boredomAmountTaken;
    public float bodyFatAmountTaken;
    public float hygieneAmountTaken;
    public float cooldown = 0;
    public float maxCooldown;
    public bool isActive = false;
    public bool onRange = false;
    public bool isBed = false;


    private TimeSpan currentCooldown;


    private void Update()
    {
        if (isActive)
        {
            cooldown -= Time.deltaTime * timeMultiplier;
        }
        if (cooldown <= 0)
        {
            isActive = false;
            if (cooldownCanvasAnim.isInitialized)
            {
                cooldownCanvasAnim.SetBool("Enable", false);
            }
        }

        currentCooldown = TimeSpan.FromSeconds(cooldown);
        string[] temptime = currentCooldown.ToString().Split(":"[0]);
        cooldownText.text = temptime[0] + ":" + temptime[1];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && other.isTrigger)
        {
            onRange = true;
            Icon.sprite = interactablesAsset.interactableSprite;
            iconBoxAnim.SetBool("Enable", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.isTrigger)
        {
            iconBoxAnim.SetBool("Enable", false);
            onRange = false;
        }
    }
}
