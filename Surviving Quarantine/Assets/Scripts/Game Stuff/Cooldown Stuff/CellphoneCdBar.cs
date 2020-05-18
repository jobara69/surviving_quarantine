using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellphoneCdBar : MonoBehaviour
{
    [SerializeField] private Cellphone cooldownSignal;
    [SerializeField] private Image fill;

    private void Update()
    {
        fill.fillAmount = cooldownSignal.cooldown / cooldownSignal.maxCooldown;
    }
}
