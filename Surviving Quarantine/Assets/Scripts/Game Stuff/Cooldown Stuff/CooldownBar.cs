using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBar : MonoBehaviour
{
    [SerializeField] private GivingSignal cooldownSignal;
    [SerializeField] private Image fill;

    private void Update()
    {
        fill.fillAmount = cooldownSignal.cooldown/cooldownSignal.maxCooldown;
    }
}
